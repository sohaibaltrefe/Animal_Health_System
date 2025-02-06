using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        Owner,
        Staff
    }

    public class Notification : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string Message { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool IsRead { get; set; } = false;

        public NotificationType Type { get; set; }

        // معلومات المرسل
        public int? SenderId { get; set; }  // يمكن أن يكون فارغًا حسب الحاجة
        public RecipientType SenderType { get; set; } // إلزامي

        // معلومات المستقبل
        public RecipientType RecipientType { get; set; } // إلزامي

        [ForeignKey(nameof(FarmStaff))]
        public int? FarmStaffId { get; set; } // قابل لـ null
        public FarmStaff FarmStaff { get; set; }

        [ForeignKey(nameof(Veterinarian))]
        public int? VeterinarianId { get; set; } // قابل لـ null
        public Veterinarian Veterinarian { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; } // قابل لـ null
        public Owner Owner { get; set; }

        // معلومات مرتبطة بالحمل والحيوان
        [ForeignKey(nameof(Pregnancy))]
        public int? PregnancyId { get; set; } // قابل لـ null
        public Pregnancy Pregnancy { get; set; }

        [ForeignKey(nameof(Animal))]
        public int? AnimalId { get; set; } // قابل لـ null
        public Animal Animal { get; set; }
    }

}
