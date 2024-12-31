using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    internal class ProductionRecordRepository : IProductionRecordRepository
    {
        public Task<int> AddAsync(ProductionRecord productionRecord)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductionRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductionRecord> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(ProductionRecord productionRecord)
        {
            throw new NotImplementedException();
        }
    }
}
