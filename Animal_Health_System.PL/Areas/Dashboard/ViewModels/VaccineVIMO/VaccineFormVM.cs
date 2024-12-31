using Animal_Health_System.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineVIMO
{
    public class VaccineFormVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vaccine name is required.")]
        [StringLength(100, ErrorMessage = "Vaccine name can't exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dose is required.")]
        [StringLength(50, ErrorMessage = "Dose can't exceed 50 characters.")]
        public string Dose { get; set; }

        [Required(ErrorMessage = "Administration date is required.")]
        public DateTime AdministrationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        // Foreign keys (nullable) for related entities
        [Required(ErrorMessage = "Medical Record is required.")]
        public int? MedicalRecordId { get; set; }

        [Required(ErrorMessage = "Veterinarian is required.")]
        public int? VeterinarianId { get; set; }

        // Drop-down lists for MedicalRecord and Veterinarian (for selection in form)
        public IEnumerable<SelectListItem> MedicalRecords { get; set; }
        public IEnumerable<SelectListItem> Veterinarians { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastModified { get; set; }
    }


      
    
}
