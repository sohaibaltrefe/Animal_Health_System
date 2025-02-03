using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FarmHealthSummaryRepository> logger;

        public FarmHealthSummaryRepository(ApplicationDbContext context, ILogger<FarmHealthSummaryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(FarmHealthSummary  farmHealthSummary)
        {
            try
            {
                await context.farmHealthSummaries.AddAsync(farmHealthSummary);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding farm Health Summaries.");
                throw new Exception("Error occurred while adding farm Health Summaries.", ex);
            }
        }

        public async Task<IEnumerable<FarmHealthSummary>> GetAllAsync()
        {
            try
            {
                return await context.farmHealthSummaries.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving farm Health Summaries.");
                throw new Exception("Error occurred while retrieving farm Health Summaries.", ex);
            }
        }

        public async Task<FarmHealthSummary> GetAsync(int id)
        {
            try
            {
                return await context.farmHealthSummaries
                    .Include(f => f.Farm)
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving farm Health Summaries.");
                throw new Exception("Error occurred while retrieving farm Health Summaries.", ex);
            }
        }

        public async Task<int> UpdateAsync(FarmHealthSummary  farmHealthSummary)
        {
            try
            {
                context.farmHealthSummaries.Update(farmHealthSummary);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating farm Health Summaries.");
                throw new Exception("Error occurred while updating farm Health Summaries.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var farmHealthSummary = await context.farmHealthSummaries.FindAsync(id);
                if (farmHealthSummary != null)
                {
                    farmHealthSummary.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting farm Health Summaries.");
                throw new Exception("Error occurred while deleting farm Health Summaries.", ex);
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
