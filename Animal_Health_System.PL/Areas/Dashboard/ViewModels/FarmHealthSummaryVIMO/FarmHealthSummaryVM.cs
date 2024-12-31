using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmHealthSummaryVIMO
{
    public class FarmHealthSummaryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }
    
        public DateTime LastUpdated { get; set; }
    }
}
