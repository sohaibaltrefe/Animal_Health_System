using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class PregnancyNotification
    {
        public int Id { get; set; }

        public string Name { get; set; }

      
        public DateTime NotificationDate { get; set; } 

        public string Message { get; set; } 

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

    }

}
