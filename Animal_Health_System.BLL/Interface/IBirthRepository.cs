using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IBirthRepository
    {
        Task<IEnumerable<Birth>> GetAllAsync();
        Task<Birth> GetAsync(int id);
        Task<int> AddAsync(Birth  birth);
        Task<int> UpdateAsync(Birth  birth);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
