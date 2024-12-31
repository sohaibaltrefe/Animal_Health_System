using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class MatingRepository : IMatingRepository
    {
        public Task<int> AddAsync(Mating mating)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Mating>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Mating> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Mating mating)
        {
            throw new NotImplementedException();
        }
    }
}
