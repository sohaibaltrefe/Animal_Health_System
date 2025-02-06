    using Animal_Health_System.DAL.Models;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AppointmentVIMO
    {
        public class AppointmentFormVM
        {
            public int Id { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "Appointment Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select an appointment date.")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; }

        // These properties are used for dropdowns
        [Required]
        public int? AnimalId { get; set; }
        public SelectList Animal { get; set; }

        [Required]
        public int? VeterinarianId { get; set; }
        public SelectList Veterinarian { get; set; }

        [Required]
        public int? OwnerId { get; set; }
        public SelectList Owner { get; set; }

        // For the dropdown of Status
        public SelectList StatusHashSet { get; set; }

        // Other properties
        public int? FarmStaffId { get; set; }
        public SelectList FarmStaff { get; set; }

    }
    }


