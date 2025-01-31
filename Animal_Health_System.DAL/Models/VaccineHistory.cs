using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public enum VaccinationStatus
    {
        Completed,
        Pending,
        Postponed
    }

    public class VaccineHistory : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }




      
        public DateTime AdministrationDate { get; set; }

        public VaccinationStatus Status { get; set; }

        public int? VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }

     
        public int? AnimalId { get; set; }
        public Animal Animal  { get; set; }

        public int? VaccineId { get; set; }
        public Vaccine Vaccine  { get; set; }

        public int? FarmStaffId { get; set; }
        public FarmStaff FarmStaff  { get; set; }
    }


}
