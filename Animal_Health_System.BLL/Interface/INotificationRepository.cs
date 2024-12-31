using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification> GetAsync(int id);
        Task<int> AddAsync(Notification  notification);
        Task<int> UpdateAsync(Notification  notification);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
