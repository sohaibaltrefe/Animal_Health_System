using Microsoft.AspNetCore.Mvc.Rendering;
using Animal_Health_System.DAL.Models;
using System.ComponentModel.DataAnnotations;


namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO
{
        public class AnimalFormVM
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Animal name is required.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Species is required.")]
            public string Species { get; set; }

            [Required(ErrorMessage = "Breed is required.")]
            public string Breed { get; set; }

            [Required(ErrorMessage = "Please select the gender.")]
            public Gender Gender { get; set; }

            [Required(ErrorMessage = "Date of Birth is required.")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Health status is required.")]
            public HealthStatus CurrentHealthStatus { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Farm is required.")]
            public int? FarmId { get; set; }

            public SelectList? Farms { get; set; } // For populating farm list in dropdown
        }



    }

