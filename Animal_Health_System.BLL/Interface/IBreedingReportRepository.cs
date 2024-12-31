using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IBreedingReportRepository
    {
        Task<IEnumerable<BreedingReport>> GetAllAsync();
        Task<BreedingReport> GetAsync(int id);
        Task<int> AddAsync(BreedingReport  breedingReport);
        Task<int> UpdateAsync(BreedingReport  breedingReport);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
