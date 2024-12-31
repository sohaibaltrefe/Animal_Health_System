using System;
using System.Collections.Generic;
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

    public class Pregnancy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime MatingDate { get; set; }

        public DateTime ExpectedBirthDate { get; set; }

        public DateTime? ActualBirthDate { get; set; }

        public PregnancyStatus Status { get; set; } 

        public bool HasComplications { get; set; }

        public string Notes { get; set; }

 public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }
        public ICollection<Birth> Births { get; set; } = new List<Birth>();

       

 public int? AnimalId { get; set; }
        public Animal Animal { get; set; }
    }


}
