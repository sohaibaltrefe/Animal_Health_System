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
    public class FarmVeterinarianRepository : IFarmVeterinarianRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<FarmVeterinarianRepository> logger;

        public FarmVeterinarianRepository(ApplicationDbContext context, ILogger<FarmVeterinarianRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(FarmVeterinarian farmVeterinarian)
        {
            try
            {
                await context.farmVeterinarians.AddAsync(farmVeterinarian);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding farmVeterinarian.");
                throw new Exception("Error occurred while adding farmVeterinarian.", ex);
            }
        }

        public async Task<IEnumerable<FarmVeterinarian>> GetAllAsync()
        {
            try
            {
                return await context.farmVeterinarians.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving farmVeterinarians.");
                throw new Exception("Error occurred while retrieving farmVeterinarians.", ex);
            }
        }

        public async Task<FarmVeterinarian> GetAsync(int id)
        {
            try
            {
                return await context.farmVeterinarians.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving farmVeterinarian.");
                throw new Exception("Error occurred while retrieving farmVeterinarian.", ex);
            }
        }

        public async Task<int> UpdateAsync(FarmVeterinarian farmVeterinarian)
        {
            try
            {
                context.farmVeterinarians.Update(farmVeterinarian);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating farmVeterinarian.");
                throw new Exception("Error occurred while updating farmVeterinarian.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var farmVeterinarian = await context.farmVeterinarians.FindAsync(id);
                if (farmVeterinarian != null)
                {
                    farmVeterinarian.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting farm Veterinarian.");
                throw new Exception("Error occurred while deleting farm Veterinarian.", ex);
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
        //public async Task<FarmVeterinarian> GetByAnimalIdAsync(int animalId)
        //{
        //    try
        //    {
        //        return await context.farmVeterinarians
        //            .FirstOrDefaultAsync(fv => fv.AnimalId == animalId && !fv.IsDeleted);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, $"Error occurred while retrieving farm veterinarian by Animal ID {animalId}.");
        //        throw new Exception($"Error occurred while retrieving farm veterinarian by Animal ID {animalId}.", ex);
        //    }
        //}
    }
}
