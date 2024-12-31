using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public enum NotificationType
    {
        VaccinationReminder, 
        HealthCheckReminder, 
        AnimalSick,         
        TreatmentUpdate     
    }

    

    public enum RecipientType
    {
        Veterinarian, 
        Owner  ,
        Staff
    }

    public class Notification
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

  public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsRead { get; set; }

        public NotificationType Type { get; set; } 

        public int? RecipientId { get; set; } 
        public RecipientType Recipient { get; set; }


        public FarmStaff FarmStaff { get; set; } 


        public Veterinarian  Veterinarian { get; set; }

        public Owner  Owner { get; set; }
    }

}
