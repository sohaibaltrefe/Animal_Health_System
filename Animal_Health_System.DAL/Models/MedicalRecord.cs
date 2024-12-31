using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public List<string> PreviousDiseases { get; set; } = new List<string>();  // تعديل هنا


        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

        public ICollection<MedicalExamination> Examinations { get; set; } = new List<MedicalExamination>();

        public ICollection<Vaccine> Vaccines { get; set; } = new List<Vaccine>();


    }
}
