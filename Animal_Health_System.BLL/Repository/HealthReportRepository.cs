using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class HealthReportRepository : IHealthReportRepository
    {
        public Task<int> AddAsync(HealthReport healthReport)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HealthReport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HealthReport> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(HealthReport healthReport)
        {
            throw new NotImplementedException();
        }
    }
}
