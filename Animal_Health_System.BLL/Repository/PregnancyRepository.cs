using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    internal class PregnancyRepository : IPregnancyRepository
    {
        public Task<int> AddAsync(Pregnancy pregnancy)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pregnancy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pregnancy> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Pregnancy pregnancy)
        {
            throw new NotImplementedException();
        }
    }
}
