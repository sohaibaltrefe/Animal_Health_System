using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class MedicalExamination : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExaminationDate { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }


        public string ExaminationType { get; set; }

      

        public int? AnimalId { get; set; }
        public Animal Animal  { get; set; }

        public int? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord  { get; set; }

        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff  { get; set; }

        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian  { get; set; }

        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();

        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();

      

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

       
    }
}
