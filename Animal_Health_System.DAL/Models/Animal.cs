using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public enum HealthStatus
    {
        Healthy, 
        Sick,          
        UnderTreatment,  
        Recovered,       
        Deceased        
    }
    public enum Gender
    {
        Male,Female
    }
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Breed { get; set; }

        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Age { get; private set; }

        public bool IsDeleted { get; set; }

        public HealthStatus CurrentHealthStatus { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? FarmId { get; set; }
        public Farm Farm { get; set; }

        public int? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public ICollection<AnimalHealthHistory> AnimalHealthHistories { get; set; } = new List<AnimalHealthHistory>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<VaccineHistory> VaccineHistories { get; set; } = new List<VaccineHistory>();

        public ICollection<MedicalExamination> MedicalExaminations { get; set; }

        public ICollection<Pregnancy> Pregnancies { get; set; }

        public ICollection<Birth> Births { get; set; }

        public ICollection<BreedingReport> BreedingReports { get; set; } = new List<BreedingReport>();

        public ICollection<FarmStaff> FarmStaffs { get; set; } 

        public void CalculateAndSetAge()
        {
            var today = DateTime.Today;
            var age = today - DateOfBirth;
            Age = $"{age.Days / 365} years, {(age.Days % 365) / 30} months, {(age.Days % 365) % 30} days";
        }
    }


}
