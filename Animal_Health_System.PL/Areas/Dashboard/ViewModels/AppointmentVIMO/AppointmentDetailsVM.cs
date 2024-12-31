using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO
{
    public class AppointmentDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string VeterinarianName { get; set; }
        public string AnimalName { get; set; }
        public string OwnerName { get; set; }
        public string FarmStaffName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
