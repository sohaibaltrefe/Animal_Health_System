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
    public class Animal: EntityBase
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
            int years = DateTime.UtcNow.Year - DateOfBirth.Year;
            return years > 1 ? $"{years} years" : "Less than a year";
        }

        public HealthStatus CurrentHealthStatus { get; set; }

        public DateTime RegistrationDate { get; set; }


        public int? FarmId { get; set; }
        public Farm Farms { get; set; }


        public int? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecords { get; set; }

        public virtual ICollection<AnimalHealthHistory> AnimalHealthHistories { get; set; } = new List<AnimalHealthHistory>();

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual ICollection<VaccineHistory> VaccineHistories { get; set; } = new List<VaccineHistory>();

        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }

        public virtual ICollection<Pregnancy> Pregnancies { get; set; }

        public virtual ICollection<Birth> Births { get; set; }

        public virtual ICollection<BreedingReport> BreedingReports { get; set; } = new List<BreedingReport>();
        public virtual ICollection<Notification>  PregnancyNotifications { get; set; } = new List< Notification>();
        public virtual ICollection<ProductionRecord>  ProductionRecords { get; set; } = new List<ProductionRecord>();

        public virtual ICollection<FarmStaff> FarmStaffs { get; set; }
       
    }


}
