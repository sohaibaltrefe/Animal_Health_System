using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentHistoryVIMO
{
    public class AppointmentHistoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string AppointmentName { get; set; }
        public string AnimalName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
