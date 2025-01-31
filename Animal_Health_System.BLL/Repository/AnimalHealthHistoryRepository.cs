using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class AnimalHealthHistoryRepository : IAnimalHealthHistoryRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<AnimalHealthHistoryRepository> logger;

        public AnimalHealthHistoryRepository(ApplicationDbContext context, ILogger<AnimalHealthHistoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(AnimalHealthHistory animalHealthHistory)
        {
            try
            {
                await context.animalHealthHistories.AddAsync(animalHealthHistory);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding animal health history.");
                throw new Exception("Error occurred while adding animal health history.", ex);
            }
        }

        public async Task<IEnumerable<AnimalHealthHistory>> GetAllAsync()
        {
            try
            {
                return await context.animalHealthHistories
                                    .Where(a => !a.IsDeleted)
                                    .Include(a => a.Animal)
                                    .ThenInclude(f => f.Farm )
                                    .Include(m => m.MedicalRecord )
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving animal health histories.");
                throw new Exception("Error occurred while retrieving animal health histories.", ex);
            }
        }

        public async Task<AnimalHealthHistory> GetAsync(int id)
        {
            try
            {
                var healthHistory = await context.animalHealthHistories
                    .Include(a => a.Animal)
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

                if (healthHistory == null)
                {
                    throw new Exception($"Animal health history with ID {id} not found.");
                }

                return healthHistory;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while retrieving animal health history with ID {id}");
                throw;
            }
        }

        public async Task<int> UpdateAsync(AnimalHealthHistory animalHealthHistory)
        {
            try
            {
                context.animalHealthHistories.Update(animalHealthHistory);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating animal health history.");
                throw new Exception("Error occurred while updating animal health history.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var animalHealthHistory = await context.animalHealthHistories.FindAsync(id);
                if (animalHealthHistory != null)
                {
                    animalHealthHistory.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Animal health history with ID: {id} not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while deleting animal health history with ID: {id}");
                throw new Exception($"Error occurred while deleting animal health history with ID: {id}", ex);
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
