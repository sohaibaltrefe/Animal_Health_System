using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_Health_System.DAL.Models
{
    public class TreatmentPlan : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TreatmentDetails { get; set; }

        public DateTime PlanDate { get; set; }

        [ForeignKey(nameof(MedicalExamination))]
        public int MedicalExaminationId { get; set; }

        public MedicalExamination MedicalExamination { get; set; }
    }
}
