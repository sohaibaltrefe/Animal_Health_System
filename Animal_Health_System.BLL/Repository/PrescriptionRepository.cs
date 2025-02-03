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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<PrescriptionRepository> logger;

        public PrescriptionRepository(ApplicationDbContext context, ILogger<PrescriptionRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Prescription  prescription)
        {
            try
            {
                await context.prescriptions.AddAsync(prescription);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding prescription.");
                throw new Exception("Error occurred while adding prescription.", ex);
            }
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync()
        {
            try
            {
                return await context.prescriptions.ToListAsync();            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving prescription.");
                throw new Exception("Error occurred while retrieving prescription.", ex);
            }
        }

        public async Task<Prescription> GetAsync(int id)
        {
            try
            {
                return await context.prescriptions
                
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving prescription.");
                throw new Exception("Error occurred while retrieving prescription.", ex);
            }
        }

        public async Task<int> UpdateAsync(Prescription prescription)
        {
            try
            {
                context.prescriptions.Update(prescription);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating prescription.");
                throw new Exception("Error occurred while updating prescription.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var prescription = await context.prescriptions.FindAsync(id);
                if (prescription != null)
                {
                    prescription.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting prescription.");
                throw new Exception("Error occurred while deleting prescription.", ex);
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
