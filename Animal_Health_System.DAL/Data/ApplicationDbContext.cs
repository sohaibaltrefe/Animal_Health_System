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
        public DbSet<Farm>  farms{ get; set; }
        public DbSet<FarmHealthSummary>  farmHealthSummaries { get; set; }

        public DbSet<Mating> matings  { get; set; }
        public DbSet<MedicalExamination> medicalExaminations  { get; set; }
        public DbSet<MedicalRecord> medicalRecords  { get; set; }
        public DbSet<Medication> medications  { get; set; }
        public DbSet<Notification>  notifications { get; set; }
        public DbSet<Owner>  owners { get; set; }
        public DbSet<Pregnancy>  pregnancies { get; set; }
        public DbSet<Vaccine>  vaccines { get; set; }
        public DbSet<VaccineHistory>  vaccineHistories { get; set; }
        public DbSet<Veterinarian>  veterinarians { get; set; }

        public DbSet<FarmStaff>  farmStaff { get; set; }
        public DbSet<FarmVeterinarian> farmVeterinarians { get; set; }
        public DbSet<HealthStatusLog>  healthStatusLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Animal -> Farm (Many-to-One)
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Farm )  // Animal has one Farm
                .WithMany(f => f.Animals) // Farm has many Animals
                .HasForeignKey(a => a.FarmId).OnDelete(DeleteBehavior.Restrict); // Foreign key in Animal



            // AnimalHealthHistory -> Animal (Many-to-One)
            modelBuilder.Entity<AnimalHealthHistory>()
                .HasOne(ahh => ahh.Animal)  // AnimalHealthHistory has one Animal
                .WithMany(a => a.AnimalHealthHistories) // Animal has many AnimalHealthHistories
                .HasForeignKey(ahh => ahh.AnimalId).OnDelete(DeleteBehavior.Restrict); // Foreign key in AnimalHealthHistory

            // Appointment -> Animal (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Animal )  // Appointment has one Animal
                .WithMany(an => an.Appointments) // Animal has many Appointments
                .HasForeignKey(a => a.AnimalId).OnDelete(DeleteBehavior.Restrict);// Foreign key in Appointment

            // Appointment -> Farm (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Farm ) // Appointment has one Farm
                .WithMany(f => f.Appointments) // Farm has many Appointments
                .HasForeignKey(a => a.FarmId).OnDelete(DeleteBehavior.Restrict); // Foreign key in Appointment

            // Appointment -> Veterinarian (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Veterinarian)  // Appointment has one Veterinarian
                .WithMany(v => v.Appointments) // Veterinarian has many Appointments
                .HasForeignKey(a => a.VeterinarianId).OnDelete(DeleteBehavior.Restrict); // Foreign key in Appointment

            // Appointment -> FarmStaff (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.FarmStaff )  // Appointment has one FarmStaff
                .WithMany(fs => fs.Appointments) // FarmStaff has many Appointments
                .HasForeignKey(a => a.FarmStaffId).OnDelete(DeleteBehavior.Restrict); // Foreign key in Appointment

            // Birth -> Pregnancy (Many-to-One)
            modelBuilder.Entity<Birth>()
                .HasOne(b => b.Pregnancy )  // Birth has one Pregnancy
                .WithMany(p => p.Births) // Pregnancy has many Births
                .HasForeignKey(b => b.PregnancyId).OnDelete(DeleteBehavior.Restrict); // Foreign key in Birth

            // Birth -> Animal (Many-to-One)
            modelBuilder.Entity<Birth>()
                .HasOne(b => b.Animal )  // Birth has one Animal
                .WithMany(a => a.Births) // Animal has many Births
                .HasForeignKey(b => b.AnimalId).OnDelete(DeleteBehavior.Restrict); // Foreign key in Birth

           
            // FarmStaff -> Farm (Many-to-One)
            modelBuilder.Entity<FarmStaff>()
                .HasOne(fs => fs.Farm)  // FarmStaff has one Farm
                .WithMany(f => f.FarmStaffs) // Farm has many FarmStaffs
                .HasForeignKey(fs => fs.FarmId).OnDelete(DeleteBehavior.Restrict); // Foreign key in FarmStaff



         

            // MedicalExamination -> Animal (Many-to-One)
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.Animal )  // MedicalExamination has one Animal
                .WithMany(a => a.MedicalExaminations) // Animal has many MedicalExaminations
                .HasForeignKey(me => me.AnimalId).OnDelete(DeleteBehavior.Restrict); // Foreign key in MedicalExamination

            // MedicalExamination -> FarmStaff (Many-to-One)
          

            // MedicalExamination -> Veterinarian (Many-to-One)
            modelBuilder.Entity<MedicalExamination>()
                .HasOne(me => me.Veterinarian )  // MedicalExamination has one Veterinarian
                .WithMany(v => v.MedicalExaminations) // Veterinarian has many MedicalExaminations
                .HasForeignKey(me => me.VeterinarianId).OnDelete(DeleteBehavior.Restrict); // Foreign key in MedicalExamination

            // MedicalRecord -> Animal (One-to-One)
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Animal )  // MedicalRecord has one Animal
                .WithOne(a => a.MedicalRecord ) // Animal has one MedicalRecord
                .HasForeignKey<MedicalRecord>(mr => mr.AnimalId).OnDelete(DeleteBehavior.Restrict);// Foreign key in MedicalRecord

            // VaccineHistory -> Animal (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Animal )  // VaccineHistory has one Animal
                .WithMany(a => a.VaccineHistories) // Animal has many VaccineHistories
                .HasForeignKey(vh => vh.AnimalId).OnDelete(DeleteBehavior.Restrict); // Foreign key in VaccineHistory

            // VaccineHistory -> Vaccine (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Vaccine )  // VaccineHistory has one Vaccine
                .WithMany(v => v.VaccineHistories) // Vaccine has many VaccineHistories
                .HasForeignKey(vh => vh.VaccineId).OnDelete(DeleteBehavior.Restrict); // Foreign key in VaccineHistory

            // VaccineHistory -> Veterinarian (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.Veterinarian)  // VaccineHistory has one Veterinarian
                .WithMany(v => v.VaccineHistories) // Veterinarian has many VaccineHistories
                .HasForeignKey(vh => vh.VeterinarianId).OnDelete(DeleteBehavior.Restrict); // Foreign key in VaccineHistory

            // VaccineHistory -> FarmStaff (Many-to-One)
            modelBuilder.Entity<VaccineHistory>()
                .HasOne(vh => vh.FarmStaff )  // VaccineHistory has one FarmStaff
                .WithMany(fs => fs.VaccineHistories) // FarmStaff has many VaccineHistories
                .HasForeignKey(vh => vh.FarmStaffId).OnDelete(DeleteBehavior.Restrict); // Foreign key in VaccineHistory

            // AppointmentHistory -> Appointment (Many-to-One)
            modelBuilder.Entity<AppointmentHistory>()
                .HasOne(ah => ah.Appointment )
                .WithMany(a => a.AppointmentHistories)
                .HasForeignKey(ah => ah.AppointmentId).OnDelete(DeleteBehavior.Restrict);

           

         

          

            // PregnancyNotification -> Animal (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(pn => pn.Animal)
                .WithMany(a => a.PregnancyNotifications)
                .HasForeignKey(pn => pn.AnimalId).OnDelete(DeleteBehavior.Restrict);

            // Owner -> Farm (One-to-Many)
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Farms)
                .WithOne(f => f.Owner )
                .HasForeignKey(f => f.OwnerId).OnDelete(DeleteBehavior.Restrict);

            // Owner -> Notification (One-to-Many)
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Notifications)
                .WithOne(n => n.Owner)
                .HasForeignKey(n => n.OwnerId).OnDelete(DeleteBehavior.Restrict);

            // Notification -> FarmStaff (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.FarmStaff)
                .WithMany(fs => fs.Notifications)
                .HasForeignKey(n => n.FarmStaffId).OnDelete(DeleteBehavior.Restrict);

            // Notification -> Veterinarian (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Veterinarian)
                .WithMany(v => v.Notifications)
                .HasForeignKey(n => n.VeterinarianId).OnDelete(DeleteBehavior.Restrict);

            // Notification -> Owner (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Owner)
                .WithMany(o => o.Notifications)
                .HasForeignKey(n => n.OwnerId).OnDelete(DeleteBehavior.Restrict);



            // Medication -> MedicalExamination (Many-to-One)
            modelBuilder.Entity<MedicalExamination>()
      .HasMany(me => me.Medications)  // الفحص الطبي يمكن أن يحتوي على أكثر من دواء
      .WithMany(m => m.MedicalExaminations)  // الدواء يمكن أن يكون مرتبطًا بعدة فحوصات طبية
      .UsingEntity(j => j.ToTable("MedicalExamination_Medication"));

            // FarmHealthSummary -> Farm (Many-to-One)
            modelBuilder.Entity<FarmHealthSummary>()
                .HasOne(fhs => fhs.Farm )
                .WithMany(f => f.FarmHealthSummaries)
                .HasForeignKey(fhs => fhs.FarmId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mating>()
        .HasOne(m => m.MaleAnimal)
        .WithMany()
        .HasForeignKey(m => m.MaleAnimalId)
        .OnDelete(DeleteBehavior.Restrict); // منع الحذف التتابعي

            modelBuilder.Entity<Mating>()
                .HasOne(m => m.FemaleAnimal)
                .WithMany()
                .HasForeignKey(m => m.FemaleAnimalId)
                .OnDelete(DeleteBehavior.Restrict);

        
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

          
            modelBuilder.Entity<Farm>()
                .HasIndex(f => new { f.Name, f.OwnerId })
                .IsUnique();

            modelBuilder.Entity<FarmHealthSummary>()
                .HasIndex(fhs => fhs.FarmId)
                .IsUnique();

            modelBuilder.Entity<FarmStaff>()
                .HasIndex(fs => new { fs.FarmId, fs.FullName })
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
            modelBuilder.Entity<MedicalRecord>()
                .HasIndex(mr => mr.Name)
                .IsUnique();
            modelBuilder.Entity<Medication>()
                .HasIndex(m => m.Name)
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

      


           

          

            modelBuilder.Entity<Vaccine>()
                .HasIndex(v => new { v.Name, v.AdministrationDate })
                .IsUnique();

            modelBuilder.Entity<VaccineHistory>()
                .HasIndex(vh => new { vh.AnimalId, vh.VaccineId, vh.AdministrationDate })
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

         

            modelBuilder.Entity<Farm>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<FarmHealthSummary>()
                .HasQueryFilter(d => !d.IsDeleted);

            modelBuilder.Entity<FarmStaff>()
                .HasQueryFilter(d => !d.IsDeleted);

           

            modelBuilder.Entity<Mating>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<MedicalExamination>()
                .HasQueryFilter(me => !me.IsDeleted);

            modelBuilder.Entity<MedicalRecord>()
                .HasQueryFilter(mr => !mr.IsDeleted);

            modelBuilder.Entity<Medication>()
                .HasQueryFilter(m => !m.IsDeleted);

          

            modelBuilder.Entity<Notification>()
                .HasQueryFilter(n => !n.IsDeleted);

            modelBuilder.Entity<Owner>()
                .HasQueryFilter(o => !o.IsDeleted);

            modelBuilder.Entity<Pregnancy>()
                .HasQueryFilter(p => !p.IsDeleted);

          
           

           

          
            modelBuilder.Entity<Vaccine>()
                .HasQueryFilter(v => !v.IsDeleted);

            modelBuilder.Entity<VaccineHistory>()
                .HasQueryFilter(vh => !vh.IsDeleted);

           

            modelBuilder.Entity<Veterinarian>()
                .HasQueryFilter(v => !v.IsDeleted);
        }



    }
}
