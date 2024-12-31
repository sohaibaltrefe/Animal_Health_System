using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Farm
    {
        public int Id { get; set; }



        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool isDeleted {  get; set; }
        
        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

        public ICollection<Birth> Births { get; set; }

        public ICollection<FarmStaff> FarmStaffs { get; set; } // الموظفين العاملين في المزرعة


    }
}
