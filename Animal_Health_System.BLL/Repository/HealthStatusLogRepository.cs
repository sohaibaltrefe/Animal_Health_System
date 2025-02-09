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
    public class HealthStatusLogRepository:IHealthStatusLogRepository
    {
       
            private readonly ApplicationDbContext context;
            private readonly ILogger<HealthStatusLogRepository> logger;

            public HealthStatusLogRepository(ApplicationDbContext context, ILogger<HealthStatusLogRepository> logger)
            {
                this.context = context;
                this.logger = logger;
            }

            public async Task<int> AddAsync(HealthStatusLog  healthStatusLog)
            {
                try
                {
                    await context.healthStatusLogs.AddAsync(healthStatusLog);
                    return await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while adding health Status Log.");
                    throw new Exception("Error occurred while adding health Status Log.", ex);
                }
            }

            public async Task<IEnumerable<HealthStatusLog>> GetAllAsync()
            {
                try
                {
                    return await context.healthStatusLogs.Where(a => !a.IsDeleted).ToListAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while retrieving Health Status Log.");
                    throw new Exception("Error occurred while retrieving Health Status Log.", ex);
                }
            }

            public async Task<HealthStatusLog> GetAsync(int id)
            {
                try
                {
                    return await context.healthStatusLogs
                      
                        .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while retrieving Health Status Log.");
                    throw new Exception("Error occurred while retrieving Health Status Log.", ex);
                }
            }

            public async Task<int> UpdateAsync(HealthStatusLog  healthStatusLog)
            {
                try
                {
                    context.healthStatusLogs.Update(healthStatusLog);
                    return await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while updating Health Status Log.");
                    throw new Exception("Error occurred while updating Health Status Log.", ex);
                }
            }

            public async Task DeleteAsync(int id)
            {
                try
                {
                    var animal = await context.animals.FindAsync(id);
                    if (animal != null)
                    {
                        animal.IsDeleted = true;
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while deleting Health Status Log.");
                    throw new Exception("Error occurred while deleting Health Status Log.", ex);
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
