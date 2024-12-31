    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Animal_Health_System.DAL.Models
    {
        public class MedicationStock
        {
            public int Id { get; set; }

        public string Name { get; set; }

         public int AvailableQuantity { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Medication> Medications { get; set; }


      
    }
    }
