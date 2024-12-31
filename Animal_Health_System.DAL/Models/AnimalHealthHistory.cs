using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public enum EventType
    {
        Disease,       
        Surgery,       
        Vaccination,    
        HealthCheck   
    }
    public class AnimalHealthHistory
    {
        public int Id { get; set; }
        
        public string Name { get; set; }


        public EventType EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

        
        public int? MedicalRecordiD { get; set; }
        public MedicalRecord  medicalRecord { get; set; }

       

    }
}
