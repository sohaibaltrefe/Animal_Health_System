using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class FarmRepository : IFarmRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<FarmRepository> logger;

        public FarmRepository(ApplicationDbContext context, ILogger<FarmRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Farm  farm)
        {
            try
            {
                await context.farms.AddAsync(farm);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding farm.");
                throw new Exception("Error occurred while adding farm.", ex);
            }
        }

        public async Task<IEnumerable<Farm>> GetAllAsync()
        {
            try
            {
                return await context.farms.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving farm.");
                throw new Exception("Error occurred while retrieving farm.", ex);
            }
        }

        public async Task<Farm> GetAsync(int id)
        {
            try
            {
                return await context.farms
                   
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving farm.");
                throw new Exception("Error occurred while retrieving farm.", ex);
            }
        }

        public async Task<int> UpdateAsync(Farm  farm)
        {
            try
            {
                context.farms.Update(farm);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating farm.");
                throw new Exception("Error occurred while updating farm.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var farm = await context.farms.FindAsync(id);
                if (farm != null)
                {
                    farm.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting farm.");
                throw new Exception("Error occurred while deleting farm.", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while saving changes.");
                throw new Exception("Error occurred while saving changes.", ex);
            }
        }
    }
}