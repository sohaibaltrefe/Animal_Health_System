using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(MedicalExamination))]
        public int  MedicalExaminationId { get; set; }

        [ForeignKey(nameof(MedicationStock))]
        public int  MedicationStockId { get; set; }

        [ForeignKey(nameof(Prescription))]
        public int  PrescriptionId { get; set; }


        public MedicalExamination MedicalExamination  { get; set; }

        public MedicationStock MedicationStock  { get; set; }

        public Prescription Prescription  { get; set; }


    }
}
