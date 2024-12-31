using Microsoft.AspNetCore.Mvc.Rendering;
using Animal_Health_System.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO
{
    public class AnimalHealthHistoryFormVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Event Type is required.")]
        public EventType EventType { get; set; }

        [Required(ErrorMessage = "Event Date is required.")]
        public DateTime EventDate { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int? AnimalId { get; set; }
        public SelectList Animals { get; set; }

        public int? MedicalRecordiD { get; set; }
        public SelectList MedicalRecords { get; set; }

        public List<SelectListItem> EventTypes { get; set; }
    }
}
