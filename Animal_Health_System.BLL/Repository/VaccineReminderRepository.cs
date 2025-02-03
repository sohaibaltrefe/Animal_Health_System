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
    public class VaccineReminderRepository: IVaccineReminderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<VaccineReminderRepository> logger;

        public VaccineReminderRepository(ApplicationDbContext context, ILogger<VaccineReminderRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(VaccineReminder  vaccineReminder)
        {
            try
            {
                await context.vaccineReminders.AddAsync(vaccineReminder);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding vaccineReminder.");
                throw new Exception("Error occurred while adding vaccineReminder.", ex);
            }
        }

        public async Task<IEnumerable<VaccineReminder>> GetAllAsync()
        {
            try
            {
                return await context.vaccineReminders.Where(a => !a.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving vaccineReminders.");
                throw new Exception("Error occurred while retrieving vaccineReminders.", ex);
            }
        }

        public async Task<VaccineReminder> GetAsync(int id)
        {
            try
            {
                return await context.vaccineReminders
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving vaccineReminder.");
                throw new Exception("Error occurred while retrieving vaccineReminder.", ex);
            }
        }

        public async Task<int> UpdateAsync(VaccineReminder vaccineReminder)
        {
            try
            {
                context.vaccineReminders.Update(vaccineReminder);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating vaccineReminder.");
                throw new Exception("Error occurred while updating vaccineReminder.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var vaccineReminder = await context.vaccineReminders.FindAsync(id);
                if (vaccineReminder != null)
                {
                    vaccineReminder.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting vaccineReminder.");
                throw new Exception("Error occurred while deleting vaccineReminder.", ex);
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
