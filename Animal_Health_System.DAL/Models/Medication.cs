using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Medication : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dosage { get; set; }

        public string Description { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public int Quantity { get; set; }


        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExaminations { get; set; }

        public int? MedicationStockId { get; set; }
        public MedicationStock MedicationStocks { get; set; }

        public int? PrescriptionId { get; set; }
        public Prescription Prescriptions { get; set; }


    }
}
