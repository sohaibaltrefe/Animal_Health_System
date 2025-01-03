﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Medication
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dosage { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }

        public int? MedicalExaminationId { get; set; }
        public MedicalExamination MedicalExamination { get; set; }

        public int? MedicationStockId { get; set; }
        public MedicationStock MedicationStock { get; set; }

        public int? PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }


    }
}
