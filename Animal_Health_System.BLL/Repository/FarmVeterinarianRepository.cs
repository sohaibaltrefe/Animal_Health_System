using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class FarmVeterinarianRepository : IFarmVeterinarianRepository
    {
        public Task<int> AddAsync(FarmVeterinarian farmVeterinarian)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FarmVeterinarian>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FarmVeterinarian> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FarmVeterinarian> GetByAnimalIdAsync(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(FarmVeterinarian farmVeterinarian)
        {
            throw new NotImplementedException();
        }
    }
}
