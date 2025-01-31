using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class TreatmentPlan : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }




        public string TreatmentDetails { get; set; } 

        public DateTime PlanDate { get; set; }

        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExamination  { get; set; }

       
    }

}
