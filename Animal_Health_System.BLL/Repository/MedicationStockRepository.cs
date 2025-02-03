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
    public class MedicationStockRepository : IMedicationStockRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<MedicationStockRepository> logger;

        public MedicationStockRepository(ApplicationDbContext context, ILogger<MedicationStockRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(MedicationStock  medicationStock)
        {
            try
            {
                await context.medicationStocks.AddAsync(medicationStock);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding medicationStock.");
                throw new Exception("Error occurred while adding medicationStock.", ex);
            }
        }

        public async Task<IEnumerable<MedicationStock>> GetAllAsync()
        {
            try
            {
                return await context.medicationStocks.Where(a => !a.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving medicationStocks.");
                throw new Exception("Error occurred while retrieving medicationStocks.", ex);
            }
        }

        public async Task<MedicationStock> GetAsync(int id)
        {
            try
            {
                return await context.medicationStocks
                   
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving medicationStock.");
                throw new Exception("Error occurred while retrieving medicationStock.", ex);
            }
        }

        public async Task<int> UpdateAsync(MedicationStock medicationStock)
        {
            try
            {
                context.medicationStocks.Update(medicationStock);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating medicationStock.");
                throw new Exception("Error occurred while updating medicationStock.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var medicationStock = await context.medicationStocks.FindAsync(id);
                if (medicationStock != null)
                {
                    medicationStock.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting medicationStock.");
                throw new Exception("Error occurred while deleting medicationStock.", ex);
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
