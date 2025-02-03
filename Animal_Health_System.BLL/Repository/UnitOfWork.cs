using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Microsoft.Extensions.Logging;
using System;

namespace Animal_Health_System.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly ILoggerFactory loggerFactory;

        public IAnimalHealthHistoryRepository animalHealthHistoryRepository { get; }

        public IAnimalRepository animalRepository { get; }


        public IAppointmentHistoryRepository appointmentHistoryRepository { get; }

        public IAppointmentRepository appointmentRepository { get; }

        public IBirthRepository birthRepository { get; }

        public IBreedingReportRepository breedingReportRepository { get; }

        public IFarmHealthSummaryRepository farmHealthSummaryRepository { get; }

        public IFarmRepository farmRepository { get; }

        public IFarmStaffRepository farmStaffRepository { get; }    

        public IFarmVeterinarianRepository farmVeterinarianRepository { get; }
        public IHealthReportRepository healthReportRepository { get; }

        public IMatingRepository matingRepository { get; }

        public IMedicalExaminationRepository medicalExaminationRepository { get; }

        public IMedicalRecordRepository medicalRecordRepository { get; }

        public IMedicationRepository medicationRepository { get; }

        public IMedicationStockRepository medicationStockRepository { get; }

        public INotificationRepository notificationRepository { get; }

        public IOwnerRepository ownerRepository { get; }

        public IPregnancyRepository pregnancyRepository { get; }

        public IPrescriptionRepository prescriptionRepository { get; }

        public IProductionRecordRepository productionRecordRepository { get; }

        public IVaccineHistoryRepository vaccineHistoryRepository { get; }

        public IVaccineReminderRepository vaccineReminderRepository { get; }

        public IVaccineRepository vaccineRepository { get; }

        public IVeterinarianRepository veterinarianRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.loggerFactory = loggerFactory;

            // Corrected: Passing the required ILogger<T> to repositories
            animalRepository = new AnimalRepository(context, loggerFactory.CreateLogger<AnimalRepository>());


            animalHealthHistoryRepository = new AnimalHealthHistoryRepository(context, loggerFactory.CreateLogger<AnimalHealthHistoryRepository>());

            appointmentHistoryRepository = new AppointmentHistoryRepository(context, loggerFactory.CreateLogger<AppointmentHistoryRepository>());

            appointmentRepository = new AppointmentRepository(context, loggerFactory.CreateLogger<AppointmentRepository>());

           birthRepository = new BirthRepository(context, loggerFactory.CreateLogger<BirthRepository>());

         breedingReportRepository = new BreedingReportRepository(context, loggerFactory.CreateLogger<BreedingReportRepository>());

        farmHealthSummaryRepository = new FarmHealthSummaryRepository(context,loggerFactory.CreateLogger<FarmHealthSummaryRepository>());

            farmRepository = new FarmRepository(context, loggerFactory.CreateLogger<FarmRepository>());

            farmVeterinarianRepository = new FarmVeterinarianRepository(context, loggerFactory.CreateLogger<FarmVeterinarianRepository>());

            farmRepository = new FarmRepository(context, loggerFactory.CreateLogger<FarmRepository>());


            healthReportRepository = new HealthReportRepository(context, loggerFactory.CreateLogger<HealthReportRepository>());

            matingRepository = new MatingRepository(context, loggerFactory.CreateLogger<MatingRepository>());

            medicalExaminationRepository = new MedicalExaminationRepository(context, loggerFactory.CreateLogger<MedicalExaminationRepository>());

            medicalRecordRepository = new MedicalRecordRepository(context, loggerFactory.CreateLogger<MedicalRecordRepository>());
            medicationRepository = new MedicationRepository(context, loggerFactory.CreateLogger<MedicationRepository>());

            medicationStockRepository = new MedicationStockRepository(context,loggerFactory.CreateLogger<MedicationStockRepository>());

            notificationRepository = new NotificationRepository(context, loggerFactory.CreateLogger<NotificationRepository>());
            ownerRepository = new OwnerRepository(context, loggerFactory.CreateLogger<OwnerRepository>());
            pregnancyRepository = new PregnancyRepository(context, loggerFactory.CreateLogger<PregnancyRepository>());
            prescriptionRepository = new PrescriptionRepository(context, loggerFactory.CreateLogger<PrescriptionRepository>());
            productionRecordRepository = new ProductionRecordRepository(context, loggerFactory.CreateLogger<ProductionRecordRepository>());
            vaccineHistoryRepository = new VaccineHistoryRepository(context, loggerFactory.CreateLogger<VaccineHistoryRepository>());
           vaccineReminderRepository = new VaccineReminderRepository(context,loggerFactory.CreateLogger<VaccineReminderRepository>());
            vaccineRepository = new VaccineRepository(context, loggerFactory.CreateLogger<VaccineRepository>());
            veterinarianRepository = new VeterinarianRepository(context, loggerFactory.CreateLogger<VeterinarianRepository>());

            
        }
    }
}
