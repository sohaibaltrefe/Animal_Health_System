using Animal_Health_System.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalExaminationVIMO
{
    public class MedicalExaminationFormVM
    {
        public int Id { get; set; }

        [Required]
        public string Diagnosis { get; set; }

        [Required]
        public string Treatment { get; set; }

        public HashSet<int> SelectedMedications { get; set; } = new HashSet<int>();

        [Required]
        public int? AnimalId { get; set; }

        public SelectList? Animal { get; set; }

        [Required]
        public int? MedicalRecordId { get; set; }

        public SelectList? MedicalRecord { get; set; }

        [Required]
        public int? VeterinarianId { get; set; }

        public SelectList? Veterinarian { get; set; }   
    }
}
