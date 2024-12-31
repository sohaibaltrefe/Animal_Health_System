using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Owner 
    {
        public int Id { get; set; }


        public string FullName { get; set; }

        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }


        public ICollection<Farm> Farms { get; set; } = new List<Farm>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

       

        public ICollection<Notification> Notifications { get; set; }


    }
}
