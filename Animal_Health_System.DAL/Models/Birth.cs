using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Birth : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public int? PregnancyId { get; set; }
        public virtual Pregnancy Pregnancy { get; set; }

        public DateTime BirthDate { get; set; }

        public int NumberOfOffspring { get; set; }

        public string BirthCondition { get; set; }

        public int? AnimalId { get; set; }
        public virtual Animal Animal { get; set; } 

        public int? FarmId { get; set; }
        public virtual Farm Farm { get; set; }
    }

}
