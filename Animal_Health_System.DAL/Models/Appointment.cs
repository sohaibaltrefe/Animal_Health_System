using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled
    }

    public class Appointment : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; }




        public int? AnimalId { get; set; }
        public Animal Animal  { get; set; }

        public int? FarmId { get; set; }
        public Farm Farm  { get; set; }

        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }


        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff  { get; set; }
        public virtual ICollection<AppointmentHistory> AppointmentHistories { get; set; } = new List<AppointmentHistory>();


        public DateTime? EndDate { get; set; }  
        public TimeSpan? AppointmentDuration
        {
            get
            {
                return EndDate.HasValue ? EndDate.Value - AppointmentDate : (TimeSpan?)null;
            }
        }
    }
}
