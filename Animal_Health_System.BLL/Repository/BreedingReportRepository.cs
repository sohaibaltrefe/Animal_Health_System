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
    public class BreedingReportRepository : IBreedingReportRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<BreedingReportRepository> logger;

        public BreedingReportRepository(ApplicationDbContext context, ILogger<BreedingReportRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(BreedingReport  breedingReport)
        {
            try
            {
                await context.breedingReports.AddAsync(breedingReport);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding breeding Report.");
                throw new Exception("Error occurred while adding breeding Report.", ex);
            }
        }

        public async Task<IEnumerable<BreedingReport>> GetAllAsync()
        {
            try
            {
                return await context.breedingReports.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving breeding Report.");
                throw new Exception("Error occurred while retrieving breeding Report.", ex);
            }
        }

        public async Task<BreedingReport> GetAsync(int id)
        {
            try
            {
                return await context.breedingReports.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving breeding Report.");
                throw new Exception("Error occurred while retrieving breeding Report.", ex);
            }
        }

        public async Task<int> UpdateAsync(BreedingReport  breedingReport)
        {
            try
            {
                context.breedingReports.Update(breedingReport);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating breeding Report.");
                throw new Exception("Error occurred while updating breeding Report.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var treatmentPlan = await context.breedingReports.FindAsync(id);
                if (treatmentPlan != null)
                {
                    treatmentPlan.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting breeding Report.");
                throw new Exception("Error occurred while deleting breeding Report.", ex);
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
