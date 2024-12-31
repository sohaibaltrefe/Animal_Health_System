using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class TreatmentPlan
    {
        public int Id { get; set; }

        public string Name { get; set; }

 public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string TreatmentDetails { get; set; } 

        public DateTime PlanDate { get; set; }

        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExamination { get; set; }

       
    }

}
