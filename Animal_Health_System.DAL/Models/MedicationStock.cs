    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Animal_Health_System.DAL.Models
    {
        public class MedicationStock : EntityBase
    {
            public int Id { get; set; }

        public string Name { get; set; }

         public int AvailableQuantity { get; set; }


        public virtual ICollection<Medication> Medications { get; set; }


      
    }
    }
