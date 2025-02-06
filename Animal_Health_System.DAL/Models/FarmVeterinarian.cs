using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class FarmVeterinarian : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [ForeignKey(nameof(Farm))]
        public int  FarmId { get; set; }


        [ForeignKey(nameof(Veterinarian))]

        public int  VeterinarianId { get; set; }
        public Farm Farm { get; set; }

        public Veterinarian Veterinarian { get; set; }
    }
}
