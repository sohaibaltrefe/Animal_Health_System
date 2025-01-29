using Animal_Health_System.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Animal_Health_System.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Animal>  animals { get; set; }
        public DbSet<AnimalHealthHistory>  animalHealthHistories { get; set; }

        public DbSet<Appointment>  appointments { get; set; }
        public DbSet<AppointmentHistory>  appointmentHistories { get; set; }

        public DbSet<Birth>  births { get; set; }
        public DbSet<BreedingReport>  breedingReports { get; set; }
        public DbSet<Farm>  farms{ get; set; }
        public DbSet<FarmHealthSummary>  farmHealthSummaries { get; set; }
        public DbSet<HealthReport> healthReports { get; set; }
        public DbSet<Mating> matings  { get; set; }
        public DbSet<MedicalExamination> medicalExaminations  { get; set; }
        public DbSet<MedicalRecord> medicalRecords  { get; set; }
        public DbSet<Medication> medications  { get; set; }
        public DbSet<MedicationStock>  medicationStocks { get; set; }
        public DbSet<Notification>  notifications { get; set; }
        public DbSet<Owner>  owners { get; set; }
        public DbSet<Pregnancy>  pregnancies { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<ProductionRecord>  productionRecords { get; set; }
        public DbSet<TreatmentPlan>  treatmentPlans { get; set; }
        public DbSet<Vaccine>  vaccines { get; set; }
        public DbSet<VaccineHistory>  vaccineHistories { get; set; }
        public DbSet<VaccineReminder>  vaccineReminders { get; set; }
        public DbSet<Veterinarian>  veterinarians { get; set; }

        public DbSet<FarmStaff>  farmStaff { get; set; }


        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is EntityBase &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (EntityBase)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.SetCreatedAt(DateTime.UtcNow); // تعيين CreatedAt عند الإضافة
                }

                entity.SetUpdatedAt(DateTime.UtcNow); // تعيين UpdatedAt عند التحديث
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            // Animal -> Farm (Many-to-One)
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Farms)  // Animal has one Farm
                .WithMany(f => f.Animals) // Farm has many Animals
                .HasForeignKey(a => a.FarmId); // Foreign key in Animal

            // Animal -> MedicalRecord (One-to-One)
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.MedicalRecords)  // Animal has one MedicalRecord
                .WithOne(mr => mr.Animals) // MedicalRecord is related to one Animal
                .HasForeignKey<MedicalRecord>(mr => mr.AnimalId); // Foreign key in MedicalRecord

            // AnimalHealthHistory -> Animal (Many-to-One)
            modelBuilder.Entity<AnimalHealthHistory>()
                .HasOne(ahh => ahh.Animal)  // AnimalHealthHistory has one Animal
                .WithMany(a => a.AnimalHealthHistories) // Animal has many AnimalHealthHistories
                .HasForeignKey(ahh => ahh.AnimalId); // Foreign key in AnimalHealthHistory

            // Appointment -> Animal (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Animals)  // Appointment has one Animal
                .WithMany(an => an.Appointments) // Animal has many Appointments
                .HasForeignKey(a => a.AnimalId);// Foreign key in Appointment

            // Appointment -> Farm (Many-to-One)
           modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Farms) // Appointment has one Farm
                .WithMany(f => f.Appointments) // Farm has many Appointments
                .HasForeignKey(a => a.FarmId); // Foreign key in Appointment
          
            // Appointment -> Veterinarian (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Veterinarian)  // Appointment has one Veterinarian
                .WithMany(v => v.Appointments) // Veterinarian has many Appointments
                .HasForeignKey(a => a.VeterinarianId); // Foreign key in Appointment

            // Appointment -> FarmStaff (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.FarmStaffs)  // Appointment has one FarmStaff
                .WithMany(fs => fs.Appointments) // FarmStaff has many Appointments
                .HasForeignKey(a => a.FarmStaffId); // Foreign key in Appointment

            // Birth -> Pregnancy (Many-to-One)
            modelBuilder.Entity<Birth>()
                .HasOne(b => b.Pregnancys)  // Birth has one Pregnancy
                .WithMany(p => p.Births) // Pregnancy has many Births
                .HasForeignKey(b => b.PregnancyId); // Foreign key in Birth

            // Birth -> Animal (Many-to-One)
            modelBuilder.Entity<Birth>()
                .HasOne(b => b.Animals)  // Birth has one Animal
                .WithMany(a => a.Births) // Animal has many Births
                .HasForeignKey(b => b.AnimalId); // Foreign key in Birth

            // BreedingReport -> Animal (Many-to-One)
            modelBuilder.Entity<BreedingReport>()
                .HasOne(br => br.Animals)  // BreedingReport has one Animal
                .WithMany(a => a.BreedingReports) // Animal has many BreedingReports
                .HasForeignKey(br => br.AnimalId); // Foreign key in BreedingReport

            // BreedingReport -> Mating (Many-to-One)
            modelBuilder.Entity<BreedingReport>()
                .HasOne(br => br.Matings)  // BreedingReport has one Mating
                .WithMany(m => m.BreedingReports) // Mating has many BreedingReports
                .HasForeignKey(br => br.MatingId); // Foreign key in BreedingReport

            // FarmStaff -> Farm (Many-to-One)
            modelBuilder.Entity<FarmStaff>()
                .HasOne(fs => fs.Farm)  // FarmStaff has one Farm
                .WithMany(f => f.FarmStaffs) // Farm has many FarmStaffs
                .HasForeignKey(fs => fs.FarmId); // Foreign key in FarmStaff

            // HealthReport -> Farm (Many-to-One)
           /* modelBuilder.Entity<HealthReport>()
                .HasOne(hr => hr.Farms)  // HealthReport has one Farm
                .WithMany(f => f.HealthReportss) // Farm has many HealthReports
                .HasForeignKey(hr => hr.FarmId); // Foreign key in HealthReport
           */
            // HealthReport -> FarmStaff (Many-to-One)
            modelBuilder.Entity<HealthReport>()
                .HasOne(hr => hr.FarmStaffs)  // HealthReport has one FarmStaff
                .WithMany(fs => fs.HealthReports) // FarmStaff has many HealthReports
                .HasForeignKey(hr => hr.FarmStaffId); // Foreign key in HealthReport

            // MedicalExamination -> Animal (Many-to-One)
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.Animals)  // MedicalExamination has one Animal
                .WithMany(a => a.MedicalExaminations) // Animal has many MedicalExaminations
                .HasForeignKey(me => me.AnimalId); // Foreign key in MedicalExamination

            // MedicalExamination -> FarmStaff (Many-to-One)
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.FarmStaffs)  // MedicalExamination has one FarmStaff
                .WithMany(fs => fs.MedicalExaminations) // FarmStaff has many MedicalExaminations
                .HasForeignKey(me => me.FarmStaffId); // Foreign key in MedicalExamination

            // MedicalExamination -> Veterinarian (Many-to-One)
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.Veterinarians)  // MedicalExamination has one Veterinarian
                .WithMany(v => v.MedicalExaminations) // Veterinarian has many MedicalExaminations
                .HasForeignKey(me => me.VeterinarianId); // Foreign key in MedicalExamination

            // MedicalRecord -> Animal (One-to-One)
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Animals)  // MedicalRecord has one Animal
                .WithOne(a => a.MedicalRecords) // Animal has one MedicalRecord
                .HasForeignKey<MedicalRecord>(mr => mr.AnimalId); // Foreign key in MedicalRecord

            // VaccineHistory -> Animal (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Animals)  // VaccineHistory has one Animal
                .WithMany(a => a.VaccineHistories) // Animal has many VaccineHistories
                .HasForeignKey(vh => vh.AnimalId); // Foreign key in VaccineHistory

            // VaccineHistory -> Vaccine (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Vaccines)  // VaccineHistory has one Vaccine
                .WithMany(v => v.VaccineHistories) // Vaccine has many VaccineHistories
                .HasForeignKey(vh => vh.VaccineId); // Foreign key in VaccineHistory

            // VaccineHistory -> Veterinarian (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Veterinarian)  // VaccineHistory has one Veterinarian
                .WithMany(v => v.VaccineHistories) // Veterinarian has many VaccineHistories
                .HasForeignKey(vh => vh.VeterinarianId); // Foreign key in VaccineHistory

            // VaccineHistory -> FarmStaff (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.FarmStaffs)  // VaccineHistory has one FarmStaff
                .WithMany(fs => fs.VaccineHistories) // FarmStaff has many VaccineHistories
                .HasForeignKey(vh => vh.FarmStaffId); // Foreign key in VaccineHistory

            // AppointmentHistory -> Appointment (Many-to-One)
            modelBuilder.Entity<AppointmentHistory>()
                .HasOne(ah => ah.Appointments)
                .WithMany(a => a.AppointmentHistories)
                .HasForeignKey(ah => ah.AppointmentId);

            // TreatmentPlan -> MedicalExamination (Many-to-One)
            modelBuilder.Entity<TreatmentPlan>()
                .HasOne(tp => tp.MedicalExaminations)
                .WithMany(me => me.TreatmentPlans)
                .HasForeignKey(tp => tp.MedicalExaminationId);

            // ProductionRecord -> Animal (Many-to-One)
            modelBuilder.Entity<ProductionRecord>()
                .HasOne(pr => pr.Animals)
                .WithMany(a => a.ProductionRecords)
                .HasForeignKey(pr => pr.AnimalId);

            // ProductionRecord -> FarmStaff (Many-to-One)
            modelBuilder.Entity<ProductionRecord>()
                .HasOne(pr => pr.FarmStaffs)
                .WithMany(fs => fs.ProductionRecords)
                .HasForeignKey(pr => pr.FarmStaffId);

            // Prescription -> MedicalExamination (Many-to-One)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.MedicalExaminations)
                .WithMany(me => me.Prescriptions)
                .HasForeignKey(p => p.MedicalExaminationId);

            // Prescription -> Medication (One-to-Many)
            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.medications)
                .WithOne(m => m.Prescriptions)
                .HasForeignKey(m => m.PrescriptionId);

            // PregnancyNotification -> Animal (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(pn => pn.Animal)
                .WithMany(a => a.PregnancyNotifications)
                .HasForeignKey(pn => pn.AnimalId);

            // Owner -> Farm (One-to-Many)
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Farms)
                .WithOne(f => f.Owners)
                .HasForeignKey(f => f.OwnerId);

            // Owner -> Notification (One-to-Many)
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Notifications)
                .WithOne(n => n.Owner)
                .HasForeignKey(n => n.OwnerId);

            // Notification -> FarmStaff (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.FarmStaff)
                .WithMany(fs => fs.Notifications)
                .HasForeignKey(n => n.FarmStaffId);

            // Notification -> Veterinarian (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Veterinarian)
                .WithMany(v => v.Notifications)
                .HasForeignKey(n => n.VeterinarianId);

            // Notification -> Owner (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Owner)
                .WithMany(o => o.Notifications)
                .HasForeignKey(n => n.OwnerId);

            // MedicationStock -> Medication (One-to-Many)
            modelBuilder.Entity<MedicationStock>()
                .HasMany(ms => ms.Medications)
                .WithOne(m => m.MedicationStocks)
                .HasForeignKey(m => m.MedicationStockId);

            // Medication -> MedicalExamination (Many-to-One)
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.MedicalExaminations)
                .WithMany(me => me.Medications)
                .HasForeignKey(m => m.MedicalExaminationId);

            // FarmHealthSummary -> Farm (Many-to-One)
            modelBuilder.Entity<FarmHealthSummary>()
                .HasOne(fhs => fhs.Farms)
                .WithMany(f => f.FarmHealthSummaries)
                .HasForeignKey(fhs => fhs.FarmId);
            //------------unique  --------------


            modelBuilder.Entity<AnimalHealthHistory>()
     .HasIndex(a => new { a.Name, a.EventDate })
     .IsUnique()
     .HasDatabaseName("Idx_AnimalHealthHistory_Name_EventDate");

            modelBuilder.Entity<AnimalHealthHistory>()
                .HasIndex(a => new { a.AnimalId, a.MedicalRecordId })
                .IsUnique()
                .HasDatabaseName("Idx_AnimalHealthHistory_AnimalId_MedicalRecordId");

            modelBuilder.Entity<Animal>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<Animal>()
                .HasIndex(a => new { a.FarmId, a.Name })
                .IsUnique();

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.AnimalId, a.AppointmentDate })
                .IsUnique();

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.AnimalId, a.AppointmentDate, a.VeterinarianId })
                .IsUnique();

            modelBuilder.Entity<AppointmentHistory>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<Birth>()
                .HasIndex(b => new { b.AnimalId, b.BirthDate })
                .IsUnique();

            modelBuilder.Entity<BreedingReport>()
                .HasIndex(br => new { br.AnimalId, br.ReportDate })
                .IsUnique();

            modelBuilder.Entity<Farm>()
                .HasIndex(f => new { f.Name, f.OwnerId })
                .IsUnique();

            modelBuilder.Entity<FarmHealthSummary>()
                .HasIndex(fhs => fhs.FarmId)
                .IsUnique();

            modelBuilder.Entity<FarmStaff>()
                .HasIndex(fs => new { fs.FarmId, fs.FullName })
                .IsUnique();

            modelBuilder.Entity<HealthReport>()
                .HasIndex(hr => new { hr.FarmId, hr.ReportDate })
                .IsUnique();

            modelBuilder.Entity<Mating>()
                .HasIndex(m => new { m.MaleAnimalId, m.FemaleAnimalId, m.MatingDate })
                .IsUnique();

            modelBuilder.Entity<MedicalExamination>()
                .HasIndex(me => new { me.AnimalId, me.ExaminationDate })
                .IsUnique();

            modelBuilder.Entity<MedicalRecord>()
                .HasIndex(mr => mr.AnimalId)
                .IsUnique();

            modelBuilder.Entity<Medication>()
                .HasIndex(m => m.Name)
                .IsUnique();

            modelBuilder.Entity<MedicationStock>()
                .HasIndex(ms => ms.Name)
                .IsUnique();

            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.Name)
                .IsUnique();

            modelBuilder.Entity<Owner>()
                .HasIndex(o => o.Email)
                .IsUnique();

            modelBuilder.Entity<Pregnancy>()
                .HasIndex(p => new { p.AnimalId, p.MatingDate })
                .IsUnique();

      

            modelBuilder.Entity<Prescription>()
                .HasIndex(pr => new { pr.MedicalExaminationId, pr.CreatedAt })
                .IsUnique();

            modelBuilder.Entity<ProductionRecord>()
                .HasIndex(pr => new { pr.AnimalId, pr.DateProduction })
                .IsUnique();

            modelBuilder.Entity<TreatmentPlan>()
                .HasIndex(tp => tp.Name)
                .IsUnique();

            modelBuilder.Entity<Vaccine>()
                .HasIndex(v => new { v.Name, v.AdministrationDate })
                .IsUnique();

            modelBuilder.Entity<VaccineHistory>()
                .HasIndex(vh => new { vh.AnimalId, vh.VaccineId, vh.AdministrationDate })
                .IsUnique();

            modelBuilder.Entity<VaccineReminder>()
                .HasIndex(vr => new { vr.AnimalId, vr.VaccineId })
                .IsUnique();

            modelBuilder.Entity<Veterinarian>()
                .HasIndex(v => v.Email)
                .IsUnique();
            // ----------soft delet ----------
            modelBuilder.Entity<AnimalHealthHistory>()
          .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<Animal>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<Appointment>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<AppointmentHistory>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<Birth>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<BreedingReport>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<Farm>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<FarmHealthSummary>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<FarmStaff>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<HealthReport>()
                .HasQueryFilter(hr => !hr.IsDeleted);

            modelBuilder.Entity<Mating>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<MedicalExamination>()
                .HasQueryFilter(me => !me.IsDeleted);

            modelBuilder.Entity<MedicalRecord>()
                .HasQueryFilter(mr => !mr.IsDeleted);

            modelBuilder.Entity<Medication>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<MedicationStock>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<Notification>()
                .HasQueryFilter(n => !n.IsDeleted);

            modelBuilder.Entity<Owner>()
                .HasQueryFilter(o => !o.IsDeleted);

            modelBuilder.Entity<Pregnancy>()
                .HasQueryFilter(p => !p.IsDeleted);

          
            modelBuilder.Entity<Prescription>()
                .HasQueryFilter(pr => !pr.IsDeleted);

            modelBuilder.Entity<ProductionRecord>()
                .HasQueryFilter(pr => !pr.IsDeleted);

            modelBuilder.Entity<TreatmentPlan>()
                .HasQueryFilter(tp => !tp.IsDeleted);

            modelBuilder.Entity<Vaccine>()
                .HasQueryFilter(v => !v.IsDeleted);

            modelBuilder.Entity<VaccineHistory>()
                .HasQueryFilter(vh => !vh.IsDeleted);

            modelBuilder.Entity<VaccineReminder>()
                .HasQueryFilter(vr => !vr.IsDeleted);

            modelBuilder.Entity<Veterinarian>()
                .HasQueryFilter(v => !v.IsDeleted);
        }



    }
}
