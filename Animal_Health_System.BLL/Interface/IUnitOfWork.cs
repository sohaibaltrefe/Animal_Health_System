using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IUnitOfWork
    {
        public IAnimalHealthHistoryRepository animalHealthHistoryRepository { get; }
        public IAnimalRepository animalRepository { get; }
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
        Task SaveChangesAsync();

    }
}
