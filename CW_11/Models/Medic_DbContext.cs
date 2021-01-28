using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_11.Models
{
    public class Medic_DbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public Medic_DbContext() { }

        public Medic_DbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription_Medicament>().HasKey(k => new
            {
                k.IdMedicament,
                k.IdPrescription
            });

            modelBuilder.Entity<Prescription_Medicament>()
              .HasOne(f => f.Prescription)
              .WithMany(f => f.Prescription_Medicaments)
              .HasForeignKey(f => f.IdPrescription);

            var doctors = new List<Doctor>();

            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Stasiek", LastName = "Ługowski", Email = "stas@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Bartek", LastName = "Kot", Email = "kot@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Matuesz", LastName = "Kownacki", Email = "mati@gmail.com" });

            modelBuilder.Entity<Doctor>().HasData(doctors);

            var patients = new List<Patient>();

            patients.Add(new Patient { IdPatient = 1, FirstName = "Antoni", LastName = "Barteczko", Birthdate = new DateTime(1944, 9, 1) });
            patients.Add(new Patient { IdPatient = 2, FirstName = "Rafał", LastName = "Puzo", Birthdate = new DateTime(1980, 1, 1) });
            patients.Add(new Patient { IdPatient = 3, FirstName = "Mateusz", LastName = "Ostaszewski", Birthdate = new DateTime(1990, 1, 1) });
            
            modelBuilder.Entity<Patient>().HasData(patients);

            var prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription { IdPrescription = 1, Date = new DateTime(2021, 1, 20), DueDate = new DateTime(2021, 2, 21), IdDoctor = 1, IdPatient = 1 });
            prescriptions.Add(new Prescription { IdPrescription = 2, Date = new DateTime(2021, 1, 20), DueDate = new DateTime(2021, 2, 24), IdDoctor = 3, IdPatient = 2 });
            prescriptions.Add(new Prescription { IdPrescription = 3, Date = new DateTime(2021, 1, 20), DueDate = new DateTime(2021, 4, 26), IdDoctor = 2, IdPatient = 3 });

            modelBuilder.Entity<Prescription>().HasData(prescriptions);

            var medicaments = new List<Medicament>();

            medicaments.Add(new Medicament { IdMedicament = 1, Name = "Rutinoscorbin", Description = "Na odporność", Type = "lek" });
            medicaments.Add(new Medicament { IdMedicament = 2, Name = "Duomox", Description = "Antybiotyk", Type = "lek" });
            medicaments.Add(new Medicament { IdMedicament = 3, Name = "Groprinosin", Description = "Walka z wirusami", Type = "lek" });

            modelBuilder.Entity<Medicament>().HasData(medicaments);

            var prescriptionsMedicament = new List<Prescription_Medicament>();

            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "informacje" });
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 2, Details = "szczegóły" });
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 3, Dose = 3, Details = "tekst" });
          
            modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptionsMedicament);
        }
    }
}
