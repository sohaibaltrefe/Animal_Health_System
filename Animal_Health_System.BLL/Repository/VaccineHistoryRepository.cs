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
    public class VaccineHistoryRepository : IVaccineHistoryRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<VaccineHistoryRepository> logger;

        public VaccineHistoryRepository(ApplicationDbContext context, ILogger<VaccineHistoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(VaccineHistory  vaccineHistory )
        {
            try
            {
                await context.vaccineHistories.AddAsync(vaccineHistory);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding  vaccine Histories.");
                throw new Exception("Error occurred while adding  vaccine Histories.", ex);
            }
        }

        public async Task<IEnumerable<VaccineHistory>> GetAllAsync()
        {
            try
            {
                return await context.vaccineHistories.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving  vaccine Histories.");
                throw new Exception("Error occurred while retrieving  vaccine Histories.", ex);
            }
        }

        public async Task<VaccineHistory> GetAsync(int id)
        {
            try
            {
                return await context.vaccineHistories

                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving  vaccine Histories.");
                throw new Exception("Error occurred while retrieving  vaccine Histories.", ex);
            }
        }

        public async Task<int> UpdateAsync(VaccineHistory vaccineHistory)
        {
            try
            {
                context.vaccineHistories.Update(vaccineHistory);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating  vaccine Histories.");
                throw new Exception("Error occurred while updating  vaccine Histories.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var vaccineHistory = await context.vaccineHistories.FindAsync(id);
                if (vaccineHistory != null)
                {
                    vaccineHistory.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting  vaccine Histories.");
                throw new Exception("Error occurred while deleting  vaccine Histories.", ex);
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
