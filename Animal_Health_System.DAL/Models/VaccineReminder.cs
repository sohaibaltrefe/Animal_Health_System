using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class VaccineReminder : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReminderDate { get; set; }

        public bool IsNotified { get; set; }




        public int? AnimalId { get; set; }
        public Animal Animal  { get; set; }

        public int? VaccineId { get; set; }
        public Vaccine Vaccine  { get; set; }


    }


}
