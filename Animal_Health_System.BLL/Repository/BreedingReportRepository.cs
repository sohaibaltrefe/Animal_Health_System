using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class BreedingReportRepository : IBreedingReportRepository
    {
        public Task<int> AddAsync(BreedingReport breedingReport)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BreedingReport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BreedingReport> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(BreedingReport breedingReport)
        {
            throw new NotImplementedException();
        }
    }
}
