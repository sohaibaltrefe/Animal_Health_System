using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmHealthSummaryVIMO
{
    public class FarmHealthSummaryDetailsVM
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int TotalAnimals { get; set; }
        public int HealthyAnimals { get; set; }
        public int SickAnimals { get; set; }
        public int AnimalsUnderTreatment { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
