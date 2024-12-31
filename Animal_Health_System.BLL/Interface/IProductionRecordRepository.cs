using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IProductionRecordRepository
    {
        Task<IEnumerable<ProductionRecord>> GetAllAsync();
        Task<ProductionRecord> GetAsync(int id);
        Task<int> AddAsync(ProductionRecord  productionRecord);
        Task<int> UpdateAsync(ProductionRecord  productionRecord);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
