using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal_Health_System.DAL.Models
{
    public enum HealthStatus
    {
        Healthy,       // عندما يكون الحيوان بصحة جيدة
        Sick,          // عندما يكون الحيوان مريضًا
        UnderTreatment,// عندما يكون الحيوان تحت العلاج
        Recovered,     // عندما يتعافى الحيوان بعد العلاج
        Deceased       // عندما يتوفى الحيوان
    }
    public class HealthStatusLog : EntityBase
    {
        public int Id { get; set; }

        public DateTime StatusDate { get; set; }

        public string HealthStatusDescription { get; set; } // وصف للحالة الصحية

        public HealthStatus HealthStatus { get; set; } // رابط للحالة الصحية (Healthy, Sick, UnderTreatment, etc.)

        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [ForeignKey(nameof(MedicalExamination))]
        public int? MedicalExaminationId { get; set; }  // رابط للفحص الطبي الذي قد يغير الحالة

        public MedicalExamination MedicalExamination { get; set; }

        
    }
}
