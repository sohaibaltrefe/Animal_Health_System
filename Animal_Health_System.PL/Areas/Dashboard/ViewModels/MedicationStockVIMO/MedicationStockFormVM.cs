using Animal_Health_System.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationStockVIMO
{
    public class MedicationStockFormVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Medication selection is required.")]
        public int? MedicationId { get; set; }

        public SelectList? Medication { get; set; }

        [Required(ErrorMessage = "Available quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Available quantity must be greater than 0.")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Last updated date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime LastUpdated { get; set; }


        public bool IsDeleted { get; set; }
    }
}
