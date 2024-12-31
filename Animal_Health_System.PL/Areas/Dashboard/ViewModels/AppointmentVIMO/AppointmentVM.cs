using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO
{
    public class AppointmentVM
    {
        public int Id { get; set; }

      
        public string Name { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }

        public string VeterinarianName { get; set; }

        public string AnimalName { get; set; }

    }
}
