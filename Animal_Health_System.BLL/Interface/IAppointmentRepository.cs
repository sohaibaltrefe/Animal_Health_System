using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetAsync(int id);
        Task<int> AddAsync(Appointment appointment);
        Task<int> UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
