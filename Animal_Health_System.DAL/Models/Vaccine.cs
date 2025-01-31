using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Animal_Health_System.DAL.Models
{
    public class Vaccine : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dose { get; set; }



        public DateTime AdministrationDate { get; set; }



        public int? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord  { get; set; }

        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian   { get; set; }

        public virtual ICollection<VaccineHistory> VaccineHistories { get; set; } = new List<VaccineHistory>();

      
    }
}
