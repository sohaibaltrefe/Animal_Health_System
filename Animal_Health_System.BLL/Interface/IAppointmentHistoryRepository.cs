using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IAppointmentHistoryRepository
    {
        Task<IEnumerable<AppointmentHistory>> GetAllAsync();
        Task<AppointmentHistory> GetAsync(int id);
        Task<int> AddAsync(AppointmentHistory appointmentHistory);
        Task<int> UpdateAsync(AppointmentHistory appointmentHistory);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
