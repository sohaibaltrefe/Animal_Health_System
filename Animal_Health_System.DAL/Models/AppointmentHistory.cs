using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class AppointmentHistory
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Status { get; set; } 

        public string Notes { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

 public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
