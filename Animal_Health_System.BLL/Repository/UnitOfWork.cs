using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly ILoggerFactory loggerFactory;

        public IAnimalRepository animalRepository { get; }
        public IAnimalHealthHistoryRepository animalHealthHistoryRepository { get; }
        public IAppointmentHistoryRepository appointmentHistoryRepository { get; }
        public IAppointmentRepository appointmentRepository { get; }
        public IBirthRepository birthRepository { get; }
        public IFarmHealthSummaryRepository farmHealthSummaryRepository { get; }
        public IFarmRepository farmRepository { get; }
        public IFarmStaffRepository farmStaffRepository { get; }

        public IMatingRepository matingRepository { get; }
        public IMedicalExaminationRepository medicalExaminationRepository { get; }
        public IMedicalRecordRepository medicalRecordRepository { get; }
        public IMedicationRepository medicationRepository { get; }
        public INotificationRepository notificationRepository { get; }
        public IOwnerRepository ownerRepository { get; }
        public IPregnancyRepository pregnancyRepository { get; }
        public IVaccineHistoryRepository vaccineHistoryRepository { get; }
        public IVaccineRepository vaccineRepository { get; }
        public IVeterinarianRepository veterinarianRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.loggerFactory = loggerFactory;

            // Initializing repositories with logging
            animalRepository = new AnimalRepository(context, loggerFactory.CreateLogger<AnimalRepository>());
            animalHealthHistoryRepository = new AnimalHealthHistoryRepository(context, loggerFactory.CreateLogger<AnimalHealthHistoryRepository>());
            appointmentHistoryRepository = new AppointmentHistoryRepository(context, loggerFactory.CreateLogger<AppointmentHistoryRepository>());
            appointmentRepository = new AppointmentRepository(context, loggerFactory.CreateLogger<AppointmentRepository>());
            birthRepository = new BirthRepository(context, loggerFactory.CreateLogger<BirthRepository>());
            farmHealthSummaryRepository = new FarmHealthSummaryRepository(context, loggerFactory.CreateLogger<FarmHealthSummaryRepository>());
            farmRepository = new FarmRepository(context, loggerFactory.CreateLogger<FarmRepository>());
            farmStaffRepository = new FarmStaffRepository(context, loggerFactory.CreateLogger<FarmStaffRepository>());
          
            matingRepository = new MatingRepository(context, loggerFactory.CreateLogger<MatingRepository>());
            medicalExaminationRepository = new MedicalExaminationRepository(context, loggerFactory.CreateLogger<MedicalExaminationRepository>());
            medicalRecordRepository = new MedicalRecordRepository(context, loggerFactory.CreateLogger<MedicalRecordRepository>());
            medicationRepository = new MedicationRepository(context, loggerFactory.CreateLogger<MedicationRepository>());
            notificationRepository = new NotificationRepository(context, loggerFactory.CreateLogger<NotificationRepository>());
            ownerRepository = new OwnerRepository(context, loggerFactory.CreateLogger<OwnerRepository>());
            pregnancyRepository = new PregnancyRepository(context, loggerFactory.CreateLogger<PregnancyRepository>());
         
            vaccineHistoryRepository = new VaccineHistoryRepository(context, loggerFactory.CreateLogger<VaccineHistoryRepository>());
            vaccineRepository = new VaccineRepository(context, loggerFactory.CreateLogger<VaccineRepository>());
            veterinarianRepository = new VeterinarianRepository(context, loggerFactory.CreateLogger<VeterinarianRepository>());
        }

        // Method to save changes to the database
        public async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while saving changes." + ex.Message, ex);
            }
        }
        // Dispose method for clean-up
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
