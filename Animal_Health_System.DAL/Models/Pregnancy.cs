using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public enum PregnancyStatus
    {
        NotPregnant,
        Pregnant,
        Complications
    }

    public class Pregnancy : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MatingDate { get; set; }
        public DateTime ExpectedBirthDate { get; set; }
        public DateTime? ActualBirthDate { get; set; }
        public PregnancyStatus Status { get; set; }
        public bool HasComplications { get; set; }
        public string Notes { get; set; }

        public ICollection<Birth> Births { get; set; } = new List<Birth>();

        // العلاقة مع الحيوان (الأنثى)
        [ForeignKey(nameof(Animal))]
        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

        // ✅ العلاقة مع التزاوج
        [ForeignKey(nameof(Mating))]
        public int MatingId { get; set; } // معرف التزاوج المرتبط بالحمل
        public Mating Mating { get; set; }

        public TimeSpan? PregnancyDuration => MatingDate != default && ExpectedBirthDate != default
            ? ExpectedBirthDate - MatingDate
            : null;

        public TimeSpan? TimeToBirth => ExpectedBirthDate != default
            ? ExpectedBirthDate - DateTime.UtcNow
            : null;
    }


}
