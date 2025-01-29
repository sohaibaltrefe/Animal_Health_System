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



        public virtual ICollection<Birth> Births { get; set; } = new List<Birth>();

       

 public int? AnimalId { get; set; }
        public Animal Animals { get; set; }



        public TimeSpan? PregnancyDuration
        {
            get
            {
                return ExpectedBirthDate - MatingDate;
            }
        }

        public TimeSpan? TimeToBirth
        {
            get
            {
                return ExpectedBirthDate - DateTime.Today;
            }
        }
    }


}
