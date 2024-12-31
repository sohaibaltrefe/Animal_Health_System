using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class VaccineHistoryRepository : IVaccineHistoryRepository
    {
        public Task<int> AddAsync(VaccineHistory vaccineHistory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VaccineHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VaccineHistory> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(VaccineHistory vaccineHistory)
        {
            throw new NotImplementedException();
        }
    }
}
