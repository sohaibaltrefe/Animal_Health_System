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
    public class MedicationRepository: IMedicationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<MedicationRepository> logger;

        public MedicationRepository(ApplicationDbContext context, ILogger<MedicationRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Medication  medication)
        {
            try
            {
                await context.medications.AddAsync(medication);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding medication.");
                throw new Exception("Error occurred while adding medication.", ex);
            }
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            try
            {
                return await context.medications.Where(a => !a.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving medications.");
                throw new Exception("Error occurred while retrieving medications.", ex);
            }
        }

        public async Task<Medication> GetAsync(int id)
        {
            try
            {
                return await context.medications
                  
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving medication.");
                throw new Exception("Error occurred while retrieving medication.", ex);
            }
        }

        public async Task<int> UpdateAsync(Medication medication)
        {
            try
            {
                context.medications.Update(medication);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating medication.");
                throw new Exception("Error occurred while updating medication.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var medication = await context.medications.FindAsync(id);
                if (medication != null)
                {
                    medication.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting medication.");
                throw new Exception("Error occurred while deleting medication.", ex);
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
