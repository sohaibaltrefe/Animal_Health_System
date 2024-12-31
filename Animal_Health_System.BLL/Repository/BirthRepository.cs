using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    internal class BirthRepository : IBirthRepository
    {
        public Task<int> AddAsync(Birth birth)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Birth>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Birth> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Birth birth)
        {
            throw new NotImplementedException();
        }
    }
}
