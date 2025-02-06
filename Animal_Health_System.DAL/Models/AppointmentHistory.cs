using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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



        [ForeignKey(nameof(Appointment))]

        public int AppointmentId { get; set; }
        public Appointment Appointment  { get; set; }

    }
}
