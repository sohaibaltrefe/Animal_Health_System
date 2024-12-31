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

    public class Appointment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Status { get; set; } 

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

  

        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }

        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }

        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff { get; set; } 
        public ICollection<AppointmentHistory> AppointmentHistories { get; set; } = new List<AppointmentHistory>();



    }

}
