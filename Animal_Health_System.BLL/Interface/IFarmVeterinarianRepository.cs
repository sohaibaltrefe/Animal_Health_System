using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface IFarmVeterinarianRepository
    {
        Task<IEnumerable<FarmVeterinarian>> GetAllAsync();
        Task<FarmVeterinarian> GetAsync(int id);
        Task<int> AddAsync(FarmVeterinarian farmVeterinarian );
        Task<int> UpdateAsync(FarmVeterinarian  farmVeterinarian);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        //Task<FarmVeterinarian> GetByAnimalIdAsync(int animalId);

    }
}
