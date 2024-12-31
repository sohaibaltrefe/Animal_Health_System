using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Mating
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime MatingDate { get; set; }  

        public string Notes { get; set; }  

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

  public int? MaleAnimalId { get; set; } 
        public Animal MaleAnimal { get; set; }

        public int? FemaleAnimalId { get; set; }  

        public Animal FemaleAnimal { get; set; }

        public ICollection<BreedingReport> BreedingReports { get; set; } = new List<BreedingReport>();


    }

}
