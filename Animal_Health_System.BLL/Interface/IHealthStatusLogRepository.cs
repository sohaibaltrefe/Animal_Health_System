using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IHealthStatusLogRepository
    {
        Task<IEnumerable<HealthStatusLog>> GetAllAsync();
        Task<HealthStatusLog> GetAsync(int id);
        Task<int> AddAsync(HealthStatusLog  healthStatusLog);
        Task<int> UpdateAsync(HealthStatusLog  healthStatusLog);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
