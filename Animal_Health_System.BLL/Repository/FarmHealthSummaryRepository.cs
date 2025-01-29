using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class FarmHealthSummaryRepository : IFarmHealthSummaryRepository
    {
        private readonly ApplicationDbContext context;

        public FarmHealthSummaryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(FarmHealthSummary  farmHealthSummary)
        {
            await context.farmHealthSummaries.AddAsync(farmHealthSummary);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FarmHealthSummary>> GetAllAsync()
        {
            return await context.farmHealthSummaries.Include(f=>f.Farms).ToListAsync();
        }

        public async Task<FarmHealthSummary> GetAsync(int id)
        {
            return await context.farmHealthSummaries
                    .Include(f => f.Farms)
                    .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> UpdateAsync(FarmHealthSummary  farmHealthSummary)
        {
            context.farmHealthSummaries.Update(farmHealthSummary);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var farmHealthSummary = await context.farmHealthSummaries.FindAsync(id);
            if (farmHealthSummary != null)
            {
                farmHealthSummary.IsDeleted = true; // Soft delete
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
