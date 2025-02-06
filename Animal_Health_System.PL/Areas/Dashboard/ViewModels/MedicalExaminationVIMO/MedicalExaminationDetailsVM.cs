using Animal_Health_System.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicalExaminationVIMO
{
    public class MedicalExaminationDetailsVM
    {
        public int Id { get; set; }
        public DateTime ExaminationDate { get; set; } 
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }

        // HashSet of Medications
        public ICollection<Medication> Medications { get; set; } = new HashSet<Medication>();

        // Foreign Key for Animal
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        // Foreign Key for MedicalRecord
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public int? VeterinarianId { get; set; }

        public Veterinarian Veterinarian { get; set; }
    }
}
