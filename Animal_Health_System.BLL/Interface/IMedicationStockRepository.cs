using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IMedicationStockRepository
    {
        Task<IEnumerable<MedicationStock>> GetAllAsync();
        Task<MedicationStock> GetAsync(int id);
        Task<int> AddAsync(MedicationStock MedicationStock);
        Task<int> UpdateAsync(MedicationStock MedicationStock);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
