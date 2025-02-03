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
    public class HealthReportRepository : IHealthReportRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<HealthReportRepository> logger;

        public HealthReportRepository(ApplicationDbContext context, ILogger<HealthReportRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(HealthReport  healthReport)
        {
            try
            {
                await context.healthReports.AddAsync(healthReport);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding healthReport.");
                throw new Exception("Error occurred while adding healthReport.", ex);
            }
        }

        public async Task<IEnumerable<HealthReport>> GetAllAsync()
        {
            try
            {
                return await context.healthReports.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving healthReports.");
                throw new Exception("Error occurred while retrieving healthReports.", ex);
            }
        }

        public async Task<HealthReport> GetAsync(int id)
        {
            try
            {
                return await context.healthReports
                    .Include(f => f.Farm)
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving healthReport.");
                throw new Exception("Error occurred while retrieving healthReport.", ex);
            }
        }

        public async Task<int> UpdateAsync(HealthReport healthReport)
        {
            try
            {
                context.healthReports.Update(healthReport);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating healthReport.");
                throw new Exception("Error occurred while updating healthReport.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var healthReport = await context.healthReports.FindAsync(id);
                if (healthReport != null)
                {
                    healthReport.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting healthReport.");
                throw new Exception("Error occurred while deleting healthReport.", ex);
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
