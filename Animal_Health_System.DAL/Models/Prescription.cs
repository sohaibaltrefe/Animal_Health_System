using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Prescription
    {
        public int Id { get; set; }


        public string Dosage { get; set; }

        public string Instructions { get; set; }

        public bool IsDeleted { get; set; }

        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExamination { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }  
        
        public ICollection<Medication> medications { get; set; } = new List<Medication>();

    }
}
