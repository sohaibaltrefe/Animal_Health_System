using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Farm : EntityBase
    {
        public int Id { get; set; }



        public string Name { get; set; }

        public string Location { get; set; }

        public int? OwnerId { get; set; }
        public Owner Owners { get; set; }

        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

        public virtual ICollection<Birth> Births { get; set; }

        public virtual ICollection<FarmStaff> FarmStaffs { get; set; }
        public virtual ICollection<Appointment>  Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<BreedingReport> BreedingReports { get; set; } = new List<BreedingReport>();

        public virtual ICollection<FarmHealthSummary>  FarmHealthSummaries { get; set; } = new List<FarmHealthSummary>();

    }
}
