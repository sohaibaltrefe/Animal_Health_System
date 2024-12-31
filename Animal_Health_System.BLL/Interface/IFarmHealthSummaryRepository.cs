using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IFarmHealthSummaryRepository
    {
        Task<IEnumerable<FarmHealthSummary>> GetAllAsync();
        Task<FarmHealthSummary> GetAsync(int id);
        Task<int> AddAsync(FarmHealthSummary  farmHealthSummary);
        Task<int> UpdateAsync(FarmHealthSummary  farmHealthSummary);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
