using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IAnimalHealthHistoryRepository
    {
        Task<IEnumerable<AnimalHealthHistory>> GetAllAsync();
        Task<AnimalHealthHistory> GetAsync(int id);
        Task<int> AddAsync(AnimalHealthHistory animalHealthHistory);
        Task<int> UpdateAsync(AnimalHealthHistory animal);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
