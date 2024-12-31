using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IPregnancyNotificationRepository
    {
        Task<IEnumerable<PregnancyNotification>> GetAllAsync();
        Task<PregnancyNotification> GetAsync(int id);
        Task<int> AddAsync(PregnancyNotification  pregnancyNotification);
        Task<int> UpdateAsync(PregnancyNotification  pregnancyNotification);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
