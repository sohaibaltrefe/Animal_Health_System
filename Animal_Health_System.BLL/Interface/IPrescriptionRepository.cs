using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllAsync();
        Task<Prescription> GetAsync(int id);
        Task<int> AddAsync(Prescription  prescription);
        Task<int> UpdateAsync(Prescription  prescription);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
