using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<VaccineRepository> logger;

        public VaccineRepository(ApplicationDbContext context, ILogger<VaccineRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Vaccine  vaccine)
        {
            try
            {
                await context.vaccines.AddAsync(vaccine);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding vaccine.");
                throw new Exception("Error occurred while adding vaccine.", ex);
            }
        }

        public async Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            try
            {
                return await context.vaccines.Where(a => !a.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving vaccines.");
                throw new Exception("Error occurred while retrieving vaccines.", ex);
            }
        }

        public async Task<Vaccine> GetAsync(int id)
        {
            try
            {
                return await context.vaccines
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving vaccine.");
                throw new Exception("Error occurred while retrieving vaccine.", ex);
            }
        }

        public async Task<int> UpdateAsync(Vaccine vaccine)
        {
            try
            {
                context.vaccines.Update(vaccine);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating vaccine.");
                throw new Exception("Error occurred while updating vaccine.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var vaccine = await context.vaccines.FindAsync(id);
                if (vaccine != null)
                {
                    vaccine.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting vaccine.");
                throw new Exception("Error occurred while deleting vaccine.", ex);
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
