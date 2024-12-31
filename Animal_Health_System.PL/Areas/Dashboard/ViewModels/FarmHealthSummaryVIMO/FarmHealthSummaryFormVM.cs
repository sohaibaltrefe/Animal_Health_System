using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmHealthSummaryVIMO
{
    public class FarmHealthSummaryFormVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Farm is required.")]
        public int? FarmId { get; set; }

        public SelectList? Farms { get; set; }

        [Required(ErrorMessage = "Total Animals is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Total Animals must be greater than 0.")]
        public int TotalAnimals { get; set; }

        [Required(ErrorMessage = "Healthy Animals is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Healthy Animals can't be negative.")]
        public int HealthyAnimals { get; set; }

        [Required(ErrorMessage = "Sick Animals is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Sick Animals can't be negative.")]
        public int SickAnimals { get; set; }

        [Required(ErrorMessage = "Animals Under Treatment is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Animals Under Treatment can't be negative.")]
        public int AnimalsUnderTreatment { get; set; }

        [Required(ErrorMessage = "Last Updated date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format.")]
        public DateTime LastUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
