using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Veterinarian : EntityBase
    {
        public int Id { get; set; }


        public string FullName { get; set; }

        public string Specialty { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int YearsOfExperience { get; set; } 




        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }

        public virtual ICollection<VaccineHistory> VaccineHistories { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }


    }
}
