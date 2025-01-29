using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class FarmStaff : EntityBase
    {
        public int Id { get; set; } 

        public string FullName { get; set; } 

        public string JobTitle { get; set; } 

        public string PhoneNumber { get; set; } 

        public string Email { get; set; } 


      
        public int? FarmId { get; set; }
        public Farm Farm { get; set; }

        public DateTime? DateHired { get; set; }  // Date when the staff member was hired
        public TimeSpan? TimeWorked
        {
            get
            {
                return DateHired.HasValue ? DateTime.Today - DateHired.Value : (TimeSpan?)null;
            }
        }

        public virtual ICollection<Appointment> Appointments { get; set; } 
        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; } 
        public virtual ICollection<ProductionRecord> ProductionRecords { get; set; } 
        public virtual ICollection<HealthReport> HealthReports { get; set; } 
        public virtual ICollection<VaccineHistory> VaccineHistories { get; set; }
    }


}
