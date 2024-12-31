using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class FarmRepository : IFarmRepository
    {
        private readonly ApplicationDbContext context;

        public FarmRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(Farm farm)
        {
            await context.farms.AddAsync(farm);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Farm>> GetAllAsync()
        {
            return await context.farms.Include(f => f.Owner).AsNoTracking().ToListAsync();
        }

        public async Task<Farm> GetAsync(int id)
        {
            return await context.farms
                .Include(f => f.Owner)
                .Include(f => f.Animals)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> UpdateAsync(Farm farm)
        {
            context.farms.Update(farm);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var farm = await context.farms.FindAsync(id);
            if (farm != null)
            {
                farm.isDeleted = true; // Soft delete
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}