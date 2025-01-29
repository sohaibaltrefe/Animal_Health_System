using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class AppointmentHistoryRepository : IAppointmentHistoryRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<AppointmentHistoryRepository> logger;

        public AppointmentHistoryRepository(ApplicationDbContext context, ILogger<AppointmentHistoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(AppointmentHistory appointmentHistory)
        {
            try
            {
                appointmentHistory.CreatedAt = DateTime.Now;
                appointmentHistory.UpdatedAt = DateTime.Now;

                await context.appointmentHistories.AddAsync(appointmentHistory);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding appointment history.");
                throw new Exception("Error occurred while adding appointment history.", ex);
            }
        }

        public async Task<IEnumerable<AppointmentHistory>> GetAllAsync()
        {
            try
            {
                return await context.appointmentHistories
                    .Include(a => a.Appointments)
                    .ThenInclude(a => a.Animals)
                    .Where(a => !a.IsDeleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving appointment histories.");
                throw new Exception("Error occurred while retrieving appointment histories.", ex);
            }
        }

        public async Task<AppointmentHistory> GetAsync(int id)
        {
            try
            {
                return await context.appointmentHistories
                    .Include(a => a.Appointments)
                    .ThenInclude(a => a.Animals)
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving appointment history.");
                throw new Exception("Error occurred while retrieving appointment history.", ex);
            }
        }

        public async Task<int> UpdateAsync(AppointmentHistory appointmentHistory)
        {
            try
            {
                appointmentHistory.UpdatedAt = DateTime.Now;

                context.appointmentHistories.Update(appointmentHistory);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating appointment history.");
                throw new Exception("Error occurred while updating appointment history.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var appointmentHistory = await context.appointmentHistories.FindAsync(id);
                if (appointmentHistory != null)
                {
                    appointmentHistory.IsDeleted = true; // Soft delete
                    appointmentHistory.UpdatedAt = DateTime.Now;

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting appointment history.");
                throw new Exception("Error occurred while deleting appointment history.", ex);
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
