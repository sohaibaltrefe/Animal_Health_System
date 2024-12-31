using Animal_Health_System.DAL.Models;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineHistoryVIMO;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO
{
    public class AnimalDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Age { get; set; }
        public HealthStatus CurrentHealthStatus { get; set; }
        public string FarmName { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<AnimalHealthHistoryVM> AnimalHealthHistories { get; set; }
        public IEnumerable<AppointmentVM> Appointments { get; set; }
        public IEnumerable<VaccineHistoryVM> VaccineHistories { get; set; }

    }
}
