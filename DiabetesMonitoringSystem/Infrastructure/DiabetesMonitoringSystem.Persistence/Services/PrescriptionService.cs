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
using Org.BouncyCastle.Asn1;

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

                if (timePeriod == TimePeriod.Morning || timePeriod == TimePeriod.Midday)
                {

                    var prescription = new Prescription();
                    prescription.PatientId = patientId;
                    prescription.PrescriptionDate = date;
                    prescription.Symptoms = symptoms;

                    var belirtiler = symptoms.OrderBy(x => x).ToList();

                    if (bsValue < 70)
                    {
                        if (belirtiler.Contains("Nöropati") || belirtiler.Contains("Polifaji") || belirtiler.Contains("Yorgunluk"))
                        {
                            prescription.Diet = "Dengeli Beslenme";
                            prescription.Exercise = "Yok";
                        }
                    }
                    else if (bsValue is > 70 and < 110)
                    {
                        if (belirtiler.Contains("Yorgunluk") || belirtiler.Contains("Kilo_Kaybı"))
                        {
                            prescription.Diet = "Az Şekerli Diyet";
                            prescription.Exercise = "Yürüyüş"; 
                        }
                        else if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                        {
                            prescription.Diet = "Dengeli Beslenme";
                            prescription.Exercise = "Yürüyüş";
                        }
                    }
                    else if (bsValue is >= 110 and < 180)
                    {
                        
                        if ((belirtiler.Contains("Bulanık_Görme") || belirtiler.Contains("Nöropati")) &&
                            !belirtiler.Contains("Poliüri") && !belirtiler.Contains("Polidipsi") &&
                            !belirtiler.Contains("Yorgunluk"))
                        {
                            prescription.Diet = "Az Şekerli Diyet"; 
                            prescription.Exercise = "Klinik Egzersiz";
                        }
                        
                        else if ((belirtiler.Contains("Poliüri") || belirtiler.Contains("Polidipsi")) &&
                                 !belirtiler.Contains("Bulanık_Görme") && !belirtiler.Contains("Nöropati") &&
                                 !belirtiler.Contains("Yorgunluk"))
                        {
                            prescription.Diet = "Şekersiz Diyet"; 
                            prescription.Exercise = "Klinik Egzersiz";
                        }
                        
                        else if (belirtiler.Contains("Yorgunluk") &&
                                 (belirtiler.Contains("Nöropati") || belirtiler.Contains("Bulanık_Görme")))
                        {
                            prescription.Diet = "Az Şekerli Diyet";
                            prescription.Exercise = "Yürüyüş";
                        }
                    }
                    else if (bsValue >= 180)
                    {
                        if (belirtiler.Contains("Yaraların_Yavaş_İyileşmesi"))
                        {
                            prescription.Diet = "Şekersiz Diyet";
                            if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                                prescription.Exercise = "Klinik Egzersiz";
                            else if (belirtiler.Contains("Kilo_Kaybı"))
                                prescription.Exercise = "Yürüyüş";
                            else
                                prescription.Exercise = "Klinik Egzersiz";
                        }
                        else if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi") || belirtiler.Contains("Kilo_Kaybı"))
                        {
                            prescription.Diet = "Şekersiz Diyet";
                            if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                                prescription.Exercise = "Klinik Egzersiz";
                            else if (belirtiler.Contains("Kilo_Kaybı"))
                                prescription.Exercise = "Yürüyüş";
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
