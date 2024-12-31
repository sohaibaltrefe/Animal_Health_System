using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class FarmStaff
    {
        public int Id { get; set; } 

        public string FullName { get; set; } 

        public string Role { get; set; } 

        public string PhoneNumber { get; set; } 

        public string Email { get; set; } 

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } 

      
        public int? FarmId { get; set; }
        public Farm Farm { get; set; }

        public int? VeterinarianId { get; set; } 
        public Veterinarian Veterinarian { get; set; } 


        public ICollection<Appointment> Appointments { get; set; } 
        public ICollection<MedicalExamination> MedicalExaminations { get; set; }
        public ICollection<Notification> Notifications { get; set; } 
        public ICollection<ProductionRecord> ProductionRecords { get; set; } 
        public ICollection<HealthReport> HealthReports { get; set; } 
        public ICollection<VaccineHistory> VaccineHistories { get; set; }
    }


}
