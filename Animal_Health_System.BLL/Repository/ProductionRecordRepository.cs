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
    public class ProductionRecordRepository : IProductionRecordRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<ProductionRecordRepository> logger;

        public ProductionRecordRepository(ApplicationDbContext context, ILogger<ProductionRecordRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(ProductionRecord  productionRecord)
        {
            try
            {
                await context.productionRecords.AddAsync(productionRecord);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding production Record.");
                throw new Exception("Error occurred while adding production Record.", ex);
            }
        }

        public async Task<IEnumerable<ProductionRecord>> GetAllAsync()
        {
            try
            {
                return await context.productionRecords.ToListAsync();           }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving production Record.");
                throw new Exception("Error occurred while retrieving production Record.", ex);
            }
        }

        public async Task<ProductionRecord> GetAsync(int id)
        {
            try
            {
                return await context.productionRecords
                  
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving production Record.");
                throw new Exception("Error occurred while retrieving production Record.", ex);
            }
        }

        public async Task<int> UpdateAsync(ProductionRecord  productionRecord)
        {
            try
            {
                context.productionRecords.Update(productionRecord);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating production Record.");
                throw new Exception("Error occurred while updating production Record.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var productionRecords = await context.productionRecords.FindAsync(id);
                if (productionRecords != null)
                {
                    productionRecords.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting production Records.");
                throw new Exception("Error occurred while deleting production Records.", ex);
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
