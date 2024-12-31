using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class ProductionRecord
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

     

        public decimal QuantityProduced { get; set; } 

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public bool IsDeleted { get; set; }

          public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff { get; set; }
    }
}
