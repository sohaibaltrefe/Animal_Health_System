using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class BreedingReport : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime ReportDate { get; set; }

       

        public string MatingDetails { get; set; }

        public string PregnancyStatus { get; set; }

        public int NumberOfOffspring { get; set; }

        public string BirthCondition { get; set; }


        [ForeignKey(nameof(Animal))]
        public int  AnimalId { get; set; } 

        [ForeignKey(nameof(Mating))]
        public int  MatingId { get; set; }  


        public Animal Animal { get; set; }  

        public Mating Mating  { get; set; }


    }

}
