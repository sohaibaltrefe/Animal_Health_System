using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    internal class PrescriptionRepository : IPrescriptionRepository
    {
        public Task<int> AddAsync(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prescription>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Prescription> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Prescription prescription)
        {
            throw new NotImplementedException();
        }
    }
}
