using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class FarmVeterinarian : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? FarmId { get; set; }
        public Farm Farm { get; set; }




        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }
    }
}
