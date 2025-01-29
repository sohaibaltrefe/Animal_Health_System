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
        TreatmentUpdate,
        PregnancyReminder
    }

    public enum RecipientType
    {
        Veterinarian, 
        Owner  ,
        Staff
    }

    public class Notification : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool IsRead { get; set; } = false;

        public NotificationType Type { get; set; } 

        public int? RecipientId { get; set; }
        public RecipientType RecipientType { get; set; }

        // Links to related entities
        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff { get; set; }

        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }

        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }

        // Pregnancy-specific properties
        public int? PregnancyId { get; set; }
        public Pregnancy Pregnancy { get; set; }

        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }
        
    }

}
