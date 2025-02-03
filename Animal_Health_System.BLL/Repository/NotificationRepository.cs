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
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<NotificationRepository> logger;

        public NotificationRepository(ApplicationDbContext context, ILogger<NotificationRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Notification  notification)
        {
            try
            {
                await context.notifications.AddAsync(notification);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding notification.");
                throw new Exception("Error occurred while adding notification.", ex);
            }
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            try
            {
                return await context.notifications.Where(a => !a.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving notifications.");
                throw new Exception("Error occurred while retrieving notifications.", ex);
            }
        }

        public async Task<Notification> GetAsync(int id)
        {
            try
            {
                return await context.notifications
                  
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving notification.");
                throw new Exception("Error occurred while retrieving notification.", ex);
            }
        }

        public async Task<int> UpdateAsync(Notification notification)
        {
            try
            {
                context.notifications.Update(notification);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating notification.");
                throw new Exception("Error occurred while updating notification.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var notification = await context.notifications.FindAsync(id);
                if (notification != null)
                {
                    notification.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting notification.");
                throw new Exception("Error occurred while deleting notification.", ex);
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
