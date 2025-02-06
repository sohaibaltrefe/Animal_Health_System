using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    public class AnimalHealthHistory : EntityBase
    {
        public int Id { get; set; }
        
        public string Name { get; set; }


        public EventType EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }



        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }

        [ForeignKey(nameof(MedicalRecord))]
        public int MedicalRecordId { get; set; }


        public Animal Animal { get; set; }
        public MedicalRecord MedicalRecord  { get; set; }

       

    }
}
