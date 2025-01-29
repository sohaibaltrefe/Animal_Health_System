using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class MedicalRecord : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

   
        public int? AnimalId { get; set; }
        public Animal Animals { get; set; }

        public virtual ICollection<MedicalExamination> Examinations { get; set; } = new List<MedicalExamination>();

        public virtual ICollection<Vaccine> Vaccines { get; set; } = new List<Vaccine>();


    }
}
