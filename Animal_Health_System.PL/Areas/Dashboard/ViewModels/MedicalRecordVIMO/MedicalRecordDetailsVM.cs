using Animal_Health_System.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalRecordVIMO
{
    public class MedicalRecordDetailsVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public ICollection<MedicalExamination> Examinations { get; set; } = new List<MedicalExamination>();
    }
}
