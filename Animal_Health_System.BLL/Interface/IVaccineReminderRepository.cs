using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IVaccineReminderRepository
    {
        Task<IEnumerable<VaccineReminder>> GetAllAsync();
        Task<VaccineReminder> GetAsync(int id);
        Task<int> AddAsync(VaccineReminder  vaccineReminder);
        Task<int> UpdateAsync(VaccineReminder  vaccineReminder);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
