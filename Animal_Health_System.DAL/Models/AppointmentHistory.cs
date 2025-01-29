using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class AppointmentHistory : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Status { get; set; } 

        public string Notes { get; set; }




 public int? AppointmentId { get; set; }
        public Appointment Appointments { get; set; }

    }
}
