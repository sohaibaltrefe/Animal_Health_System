using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<MedicalRecordRepository> logger;

        public MedicalRecordRepository(ApplicationDbContext context, ILogger<MedicalRecordRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(MedicalRecord medicalRecord)
        {
            try
            {
                await context.medicalRecords.AddAsync(medicalRecord);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to add medical record.");
                throw;
            }
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
        {
            try
            {
                return await context.medicalRecords
                    .Where(a => !a.IsDeleted)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to retrieve medical records.");
                throw;
            }
        }

        public async Task<MedicalRecord> GetAsync(int id)
        {
            try
            {
                return await context.medicalRecords
                    .Include(m => m.Animal)
                    .Include(m => m.Examinations)
                    .Include(m => m.Vaccines)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to retrieve medical record with ID {id}.");
                throw;
            }
        }

        public async Task<int> UpdateAsync(MedicalRecord medicalRecord)
        {
            try
            {
                context.medicalRecords.Update(medicalRecord);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to update medical record.");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var medicalRecord = await context.medicalRecords
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

                if (medicalRecord == null)
                {
                    logger.LogWarning($"Medical record ID {id} not found for deletion.");
                    return;
                }

                medicalRecord.IsDeleted = true;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to delete medical record.");
                throw;
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<MedicalRecord, bool>> predicate)
        {
            try
            {
                return await context.medicalRecords.AsNoTracking().AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error checking medical record existence.");
                throw;
            }
        }

        public async Task<MedicalRecord> GetByAnimalIdAsync(int animalId)
        {
            try
            {
                return await context.medicalRecords
                    .Include(m => m.Animal)
                    .Include(m => m.Examinations)
                    .Include(m => m.Vaccines)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.AnimalId == animalId && !m.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to retrieve medical record for AnimalId {animalId}.");
                throw;
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
                logger.LogError(ex, "Failed to save changes.");
                throw;
            }
        }
    }
}
