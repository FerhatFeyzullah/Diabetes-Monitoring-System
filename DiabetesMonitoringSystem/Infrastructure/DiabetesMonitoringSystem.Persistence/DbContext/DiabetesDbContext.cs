using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.DbContext
{
    public class DiabetesDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public DiabetesDbContext(DbContextOptions<DiabetesDbContext> options) : base(options)
        {
        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<BloodSugar> BloodSugars { get; set; }
        public DbSet<DailyStatus> DailyStatuses { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Insulin> Insulins { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PatientSymptom> PatientSymptoms { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }

    }
}
