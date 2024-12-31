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
        public DbSet<PregnancyNotification>  pregnancyNotifications { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<ProductionRecord>  productionRecords { get; set; }
        public DbSet<TreatmentPlan>  treatmentPlans { get; set; }
        public DbSet<Vaccine>  vaccines { get; set; }
        public DbSet<VaccineHistory>  vaccineHistories { get; set; }
        public DbSet<VaccineReminder>  vaccineReminders { get; set; }
        public DbSet<Veterinarian>  veterinarians { get; set; }

        public DbSet<FarmStaff>  farmStaff { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // *********لعلاقات********* 

            // One-to-many 
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Farm)
                .WithMany(f => f.Animals)
                .HasForeignKey(a => a.FarmId)
                .OnDelete(DeleteBehavior.SetNull);

            // ********** One-to-one *******
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.MedicalRecord)
                .WithOne(mr => mr.Animal)
                .HasForeignKey<Animal>(a => a.MedicalRecordId)
                .OnDelete(DeleteBehavior.SetNull);

           

            //*********** One-to-many *************
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Animal)
                .WithMany(an => an.Appointments)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            //***************** One-to-many ***************
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Veterinarian)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VeterinarianId)
                .OnDelete(DeleteBehavior.SetNull);

            //*************** One-to-many *************
            modelBuilder.Entity<Appointment>()
                .HasOne(app => app.Owner)
                .WithMany(owner => owner.Appointments)
                .HasForeignKey(app => app.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many ***************
            modelBuilder.Entity<AppointmentHistory>()
                .HasOne(ah => ah.Appointment)
                .WithMany(a => a.AppointmentHistories)
                .HasForeignKey(ah => ah.AppointmentId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many ************
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Animal)
                .WithMany(a => a.VaccineHistories)
                .HasForeignKey(vh => vh.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many ***********
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Vaccine)
                .WithMany(v => v.VaccineHistories)
                .HasForeignKey(vh => vh.VaccineId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many************
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.Animal)
                .WithMany(a => a.MedicalExaminations)
                .HasForeignKey(me => me.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            //************* One-to-many **********
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.Veterinarian)
                .WithMany(v => v.MedicalExaminations)
                .HasForeignKey(me => me.VeterinarianId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many *************
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.MedicalExamination)
                .WithMany(me => me.Medications)
                .HasForeignKey(m => m.MedicalExaminationId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many ***********
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.MedicationStock)
                .WithMany(ms => ms.Medications)
                .HasForeignKey(m => m.MedicationStockId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many ************
            modelBuilder.Entity<Farm>()
                .HasOne(f => f.Owner)
                .WithMany(o => o.Farms)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            //*********** One-to-many **********
            modelBuilder.Entity<Pregnancy>()
                .HasOne(p => p.Animal)
                .WithMany(a => a.Pregnancies)
                .HasForeignKey(p => p.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many ************
            modelBuilder.Entity<Pregnancy>()
                .HasMany(p => p.Births)
                .WithOne(b => b.Pregnancy)
                .HasForeignKey(b => b.PregnancyId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many   ************
            modelBuilder.Entity<Birth>()
                .HasOne(b => b.Animal)
                .WithMany(a => a.Births)
                .HasForeignKey(b => b.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            //*************** One-to-many ***************
            modelBuilder.Entity<Birth>()
                .HasOne(b => b.Farm)
                .WithMany(f => f.Births)
                .HasForeignKey(b => b.FarmId)
                .OnDelete(DeleteBehavior.SetNull);

            //**************** One-to-many *****************
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Appointments)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            //*********** One-to-many ***********
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Farms)
                .WithOne(f => f.Owner)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            //************* One-to-many ************
            modelBuilder.Entity<Veterinarian>()
                .HasMany(v => v.Appointments)
                .WithOne(a => a.Veterinarian)
                .HasForeignKey(a => a.VeterinarianId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many ***********
            modelBuilder.Entity<Veterinarian>()
                .HasMany(v => v.MedicalExaminations)
                .WithOne(me => me.Veterinarian)
                .HasForeignKey(me => me.VeterinarianId)
                .OnDelete(DeleteBehavior.SetNull);

            //******** One-to-many ********
            modelBuilder.Entity<Veterinarian>()
                .HasMany(v => v.VaccineHistories)
                .WithOne(vh => vh.Veterinarian)
                .HasForeignKey(vh => vh.VeterinarianId)
                .OnDelete(DeleteBehavior.SetNull);

            //******** One-to-many **********
            modelBuilder.Entity<MedicationStock>()
                .HasMany(ms => ms.Medications)
                .WithOne(m => m.MedicationStock)
                .HasForeignKey(m => m.MedicationStockId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many ********
            modelBuilder.Entity<Vaccine>()
                .HasMany(v => v.VaccineHistories)
                .WithOne(vh => vh.Vaccine)
                .HasForeignKey(vh => vh.VaccineId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many  **********
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Owner)
                .WithMany(o => o.Notifications)
                .HasForeignKey(n => n.RecipientId)
                .OnDelete(DeleteBehavior.SetNull);

            // ********** One-to-many ***********
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Veterinarian)
                .WithMany(v => v.Notifications)
                .HasForeignKey(n => n.RecipientId)
                .OnDelete(DeleteBehavior.SetNull);

            // ******** One-to-many *********
            modelBuilder.Entity<BreedingReport>()
                .HasOne(br => br.Animal)
                .WithMany(a => a.BreedingReports)
                .HasForeignKey(br => br.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many  **************
            modelBuilder.Entity<BreedingReport>()
                .HasOne(br => br.Mating)
                .WithMany(m => m.BreedingReports)
                .HasForeignKey(br => br.MatingId)
                .OnDelete(DeleteBehavior.SetNull);

            //************ One-to-many ***********
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.Prescription)
                .WithMany(p => p.medications)
                .HasForeignKey(m => m.PrescriptionId)
                .OnDelete(DeleteBehavior.SetNull);

            //********** One-to-many *********
            modelBuilder.Entity<FarmStaff>()
                .HasOne(fs => fs.Farm)
                .WithMany(f => f.FarmStaffs)
                .HasForeignKey(fs => fs.FarmId)
                .OnDelete(DeleteBehavior.SetNull);

            //   ******* One-to-many ******
            modelBuilder.Entity<FarmStaff>()
                .HasOne(fs => fs.Veterinarian)
                .WithMany(v => v.FarmStaffs)
                .HasForeignKey(fs => fs.VeterinarianId)
                .OnDelete(DeleteBehavior.SetNull);



            //------------unique  --------------


            modelBuilder.Entity<AnimalHealthHistory>()
       .HasIndex(a => new { a.Name, a.EventDate })
       .IsUnique()
       .HasDatabaseName("Idx_AnimalHealthHistory_Name_EventDate");

            modelBuilder.Entity<AnimalHealthHistory>()
                .HasIndex(a => new { a.AnimalId, a.MedicalRecordiD })
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

            modelBuilder.Entity<Animal>()
                .HasIndex(a => a.Name)
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

            modelBuilder.Entity<PregnancyNotification>()
                .HasIndex(pn => new { pn.AnimalId, pn.NotificationDate })
                .IsUnique(); 

            modelBuilder.Entity<Prescription>()
                .HasIndex(pr => new { pr.MedicalExaminationId, pr.CreatedAt })
                .IsUnique(); 

            modelBuilder.Entity<ProductionRecord>()
                .HasIndex(pr => new { pr.AnimalId, pr.Date })
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
                .HasQueryFilter(d => !d.isDeleted);
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
            modelBuilder.Entity<PregnancyNotification>()
                .HasQueryFilter(pn => !pn.IsDeleted);
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
