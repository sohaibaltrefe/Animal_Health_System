using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Prescription : EntityBase
    {
        public int Id { get; set; }


        public string Dosage { get; set; }

        public string Instructions { get; set; }


        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExaminations { get; set; }

        
        public virtual ICollection<Medication> medications { get; set; } = new List<Medication>();

    }
}
