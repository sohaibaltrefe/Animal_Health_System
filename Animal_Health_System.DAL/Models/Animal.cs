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
            var age = DateTime.UtcNow - DateOfBirth;
            int years = (int)(age.TotalDays / 365.25);
            int months = (int)((age.TotalDays % 365.25) / 30.44);

            if (years > 0)
                return $"{years} years, {months} months";
            return $"{months} months";
        }

        public HealthStatus CurrentHealthStatus { get; set; }



        public int?  FarmId { get; set; }
        public virtual Farm Farm  { get; set; }


        public int? MedicalRecordId { get; set; }
        public virtual  MedicalRecord MedicalRecord  { get; set; }

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
