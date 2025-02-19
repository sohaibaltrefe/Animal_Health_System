﻿using Animal_Health_System.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineHistoryVIMO
{
    public class VaccineHistoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AdministrationDate { get; set; }
        public int VeterinarianId { get; set; }
        public int MedicalRecordId { get; set; }
        public int VaccineId { get; set; }
        public Veterinarian Veterinarian { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

    }
}
