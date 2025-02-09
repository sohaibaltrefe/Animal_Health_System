using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineHistoryVIMO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO
{
    public class AnimalDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public decimal Weight { get; set; }
        public string Age { get; set; }
        public HealthStatus CurrentHealthStatus { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public ICollection<AnimalHealthHistory> AnimalHealthHistories { get; set; } = new List<AnimalHealthHistory>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<VaccineHistory> VaccineHistories { get; set; } = new List<VaccineHistory>();
        public ICollection<MedicalExamination> MedicalExaminations { get; set; } = new List<MedicalExamination>();
        public ICollection<Pregnancy> Pregnancies { get; set; } = new List<Pregnancy>();
        public ICollection<BreedingReport> BreedingReports { get; set; } = new List<BreedingReport>();
        public ICollection<Notification> PregnancyNotifications { get; set; } = new List<Notification>();
        public ICollection<ProductionRecord> ProductionRecords { get; set; } = new List<ProductionRecord>();
        public ICollection<FarmStaff> FarmStaffs { get; set; } = new List<FarmStaff>();

    }
}
