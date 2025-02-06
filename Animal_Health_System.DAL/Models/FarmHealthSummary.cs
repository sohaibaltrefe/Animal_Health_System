using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class FarmHealthSummary : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int TotalAnimals { get; set; }

        public int HealthyAnimals { get; set; }

        public int SickAnimals { get; set; }

        public int UnderTreatment { get; set; }


        [ForeignKey(nameof(Farm))]


        public int  FarmId { get; set; }
        public Farm Farm  { get; set; }
    }

}
