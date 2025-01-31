using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class ProductionRecord : EntityBase
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
         
        public decimal QuantityProduced { get; set; } 

        public DateTime DateProduction { get; set; }

        public string TypeProduction { get; set; }


          public int? AnimalId { get; set; }
        public Animal Animal  { get; set; }

        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff  { get; set; }
    }
}
