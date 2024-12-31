using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Birth
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int? PregnancyId { get; set; } 
        
        public Pregnancy Pregnancy { get; set; }

        public DateTime BirthDate { get; set; }  

        public int NumberOfOffspring { get; set; } 

        public string BirthCondition { get; set; } 

        public bool IsDeleted { get; set; }

 public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }


        public int? FarmId { get; set; }
        public Farm Farm { get; set; }
       

    }

}
