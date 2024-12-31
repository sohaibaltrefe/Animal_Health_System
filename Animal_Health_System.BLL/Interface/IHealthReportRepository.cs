using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IHealthReportRepository
    {
        Task<IEnumerable<HealthReport>> GetAllAsync();
        Task<HealthReport> GetAsync(int id);
        Task<int> AddAsync(HealthReport  healthReport);
        Task<int> UpdateAsync(HealthReport  healthReport);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
