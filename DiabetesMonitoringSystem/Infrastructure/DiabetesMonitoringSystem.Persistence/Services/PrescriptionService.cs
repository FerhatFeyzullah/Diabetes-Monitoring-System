using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Domain.Enums;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly DiabetesDbContext _context;
        private readonly IDS_Service _ids;

        public PrescriptionService(DiabetesDbContext context, IDS_Service ids)
        {
            _context = context;
            _ids = ids;
        }

        public async Task CreatePrescriptionAsync(int patientId, int bsValue, List<string> symptoms, DateOnly date, TimePeriod timePeriod)
        {
            var prescriptionExist = await _context.DailyStatuses
                                    .AnyAsync(x => x.PatientId == patientId && x.Date == date && x.PrescriptionAvailable);



            if (!prescriptionExist)
            {
                var doctorId = await _context.Users
                    .Where(x => x.Id == patientId)
                    .Select(x => x.DoctorId)
                    .FirstOrDefaultAsync();


                if (timePeriod == TimePeriod.Morning || timePeriod == TimePeriod.Midday)
                {

                    var prescription = new Prescription();
                    prescription.DoctorId = doctorId.Value;
                    prescription.PatientId = patientId;
                    prescription.PrescriptionDate = date;

                    var belirtiler = symptoms.OrderBy(x => x).ToList();

                    if (bsValue < 70)
                    {
                        if (belirtiler.Contains("Nöropati") || belirtiler.Contains("Polifaji") || belirtiler.Contains("Yorgunluk"))
                        {
                            prescription.DietId = 3; // Dengeli Beslenme
                            prescription.ExerciseId = 1; // Yok
                        }
                    }
                    else if (bsValue is > 70 and < 110)
                    {
                        if (belirtiler.Contains("Yorgunluk") || belirtiler.Contains("Kilo Kaybı"))
                        {
                            prescription.DietId = 1; // Az Şekerli Diyet
                            prescription.ExerciseId = 2; // Yürüyüş
                        }
                        else if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                        {
                            prescription.DietId = 3; // Dengeli Beslenme
                            prescription.ExerciseId = 2; // Yürüyüş
                        }
                    }
                    else if (bsValue is >= 110 and < 180)
                    {
                        // 1. Koşul: Bulanık Görme, Nöropati
                        if ((belirtiler.Contains("Bulanık Görme") || belirtiler.Contains("Nöropati")) &&
                            !belirtiler.Contains("Poliüri") && !belirtiler.Contains("Polidipsi") &&
                            !belirtiler.Contains("Yorgunluk"))
                        {
                            prescription.DietId = 1; // Az Şekerli Diyet
                            prescription.ExerciseId = 4; // Klinik Egzersiz
                        }
                        // 2. Koşul: Poliüri, Polidipsi
                        else if ((belirtiler.Contains("Poliüri") || belirtiler.Contains("Polidipsi")) &&
                                 !belirtiler.Contains("Bulanık Görme") && !belirtiler.Contains("Nöropati") &&
                                 !belirtiler.Contains("Yorgunluk"))
                        {
                            prescription.DietId = 2; // Şekersiz Diyet
                            prescription.ExerciseId = 4; // Klinik Egzersiz
                        }
                        // 3. Koşul: Yorgunluk, Nöropati, Bulanık Görme
                        else if (belirtiler.Contains("Yorgunluk") &&
                                 (belirtiler.Contains("Nöropati") || belirtiler.Contains("Bulanık Görme")))
                        {
                            prescription.DietId = 1; // Az Şekerli Diyet
                            prescription.ExerciseId = 2; // Yürüyüş
                        }
                    }
                    else if (bsValue >= 180)
                    {
                        if (belirtiler.Contains("Yaraların Yavaş İyileşmesi"))
                        {
                            prescription.DietId = 2; // Şekersiz Diyet
                            if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                                prescription.ExerciseId = 4; // Klinik Egzersiz
                            else if (belirtiler.Contains("Kilo Kaybı"))
                                prescription.ExerciseId = 2; // Yürüyüş
                            else
                                prescription.ExerciseId = 4; // Klinik Egzersiz
                        }
                        else if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi") || belirtiler.Contains("Kilo Kaybı"))
                        {
                            prescription.DietId = 2; // Şekersiz Diyet
                            if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                                prescription.ExerciseId = 4; // Klinik Egzersiz
                            else if (belirtiler.Contains("Kilo Kaybı"))
                                prescription.ExerciseId = 2; // Yürüyüş
                        }
                    }

                    await _context.Prescriptions.AddAsync(prescription);
                    await _context.SaveChangesAsync();
                    await _ids.PrescriptionOk(patientId,date);


                }
            }

            
        }
    }
}
