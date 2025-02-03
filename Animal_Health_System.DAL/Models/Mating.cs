using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Mating : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime MatingDate { get; set; }  

        public string Notes { get; set; }

        public int? FarmId { get; set; }
        public Farm farm { get; set; }

        public int? MaleAnimalId { get; set; } 
        public Animal MaleAnimal { get; set; }

        public int? FemaleAnimalId { get; set; }  

        public Animal FemaleAnimal { get; set; }

        public virtual ICollection<BreedingReport> BreedingReports { get; set; } = new List<BreedingReport>();


    }

}
