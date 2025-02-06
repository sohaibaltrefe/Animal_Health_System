using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(MedicalExamination))]

        public int  MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExaminations { get; set; }

        
        public   ICollection<Medication> medications { get; set; } = new List <Medication>();

    }
}
