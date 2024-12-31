using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class BreedingReport
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime ReportDate { get; set; }

       

        public string MatingDetails { get; set; }

        public string PregnancyStatus { get; set; }

        public int NumberOfOffspring { get; set; }

        public string BirthCondition { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

 public int? AnimalId { get; set; } 
        public Animal Animal { get; set; }  

        public int? MatingId { get; set; }  
        public Mating Mating { get; set; }


    }

}
