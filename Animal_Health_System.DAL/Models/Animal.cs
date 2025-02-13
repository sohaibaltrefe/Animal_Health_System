﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_Health_System.DAL.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Animal : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Breed { get; set; }

        public decimal Weight { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Age => CalculateAge();

        private string CalculateAge()
        {
            var age = DateTime.UtcNow - DateOfBirth;
            int years = (int)(age.TotalDays / 365.25);
            int months = (int)((age.TotalDays % 365.25) / 30.44);
            int days = (int)((age.TotalDays % 365.25) % 30.44);

            if (years > 0)
                return $"{years} years, {months} months, {days} days";
            if (months > 0)
                return $"{months} months, {days} days";
            return $"{days} days";
        }

        [ForeignKey(nameof(Farm))]
        public int FarmId { get; set; }

        [ForeignKey(nameof(MedicalRecord))]
        public int MedicalRecordId { get; set; }

        public Farm Farm { get; set; }

        public MedicalRecord MedicalRecord { get; set; }

        public ICollection<AnimalHealthHistory> AnimalHealthHistories { get; set; } = new List<AnimalHealthHistory>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<VaccineHistory> VaccineHistories { get; set; } = new List<VaccineHistory>();

        public ICollection<MedicalExamination> MedicalExaminations { get; set; } = new List<MedicalExamination>();

        public ICollection<Pregnancy> Pregnancies { get; set; } = new List<Pregnancy>();

        public ICollection<Birth> Births { get; set; } = new List<Birth>();


        public ICollection<Notification> PregnancyNotifications { get; set; } = new List<Notification>();


        public ICollection<FarmStaff> FarmStaffs { get; set; } = new List<FarmStaff>();
    }
}
