using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentHistoryVIMO
{
    public class AppointmentHistoryDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string AppointmentName { get; set; }
        public Animal animal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
