using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public decimal salary { get; set; }
        [ForeignKey(nameof(Farm))]

        public int  FarmId { get; set; }
        public Farm Farm { get; set; }

        public DateTime? DateHired { get; set; }  // Date when the staff member was hired
        public TimeSpan? TimeWorked
        {
            get
            {
                return DateHired.HasValue ? DateTime.Today - DateHired.Value : (TimeSpan?)null;
            }
        }

        public   ICollection<Appointment> Appointments { get; set; } = new List <Appointment>();
         public   ICollection<Notification> Notifications { get; set; } = new List <Notification>();
        public   ICollection<HealthReport> HealthReports { get; set; } = new List <HealthReport>();
        public   ICollection<VaccineHistory> VaccineHistories { get; set; } = new List <VaccineHistory>();
    }


}
