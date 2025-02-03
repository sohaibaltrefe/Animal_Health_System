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
    public class TreatmentPlanRepository:ITreatmentPlanRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<TreatmentPlanRepository> logger;

        public TreatmentPlanRepository(ApplicationDbContext context, ILogger<TreatmentPlanRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(TreatmentPlan  treatmentPlan)
        {
            try
            {
                await context.treatmentPlans.AddAsync(treatmentPlan);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding treatment Plan.");
                throw new Exception("Error occurred while adding treatment Plan.", ex);
            }
        }

        public async Task<IEnumerable<TreatmentPlan>> GetAllAsync()
        {
            try
            {
                return await context.treatmentPlans.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving treatment Plan.");
                throw new Exception("Error occurred while retrieving treatment Plan.", ex);
            }
        }

        public async Task<TreatmentPlan> GetAsync(int id)
        {
            try
            {
                return await context.treatmentPlans
                  
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving treatment Plan.");
                throw new Exception("Error occurred while retrieving treatment Plan.", ex);
            }
        }

        public async Task<int> UpdateAsync(TreatmentPlan  treatmentPlan)
        {
            try
            {
                context.treatmentPlans.Update(treatmentPlan);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating treatment Plan.");
                throw new Exception("Error occurred while updating treatment Plan.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var treatmentPlan = await context.treatmentPlans.FindAsync(id);
                if (treatmentPlan != null)
                {
                    treatmentPlan.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting treatment Plan.");
                throw new Exception("Error occurred while deleting treatment Plan.", ex);
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
