using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<AppointmentRepository> logger;

        public AppointmentRepository(ApplicationDbContext context, ILogger<AppointmentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Appointment appointment)
        {
            try
            {
                await context.appointments.AddAsync(appointment);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding appointment.");
                throw new Exception("Error occurred while adding appointment.", ex);
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            try
            {
                return await context.appointments
                    .Include(a => a.Veterinarian)
                    .Include(a => a.Animal  )
                    .Where(a => !a.IsDeleted)  // Make sure not to fetch deleted appointments
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching all appointments.");
                throw new Exception("Error occurred while fetching all appointments.", ex);
            }
        }

        public async Task<Appointment> GetAsync(int id)
        {
            try
            {
                return await context.appointments
                    .Include(a => a.Veterinarian)
                    .Include(a => a.Animal )
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted); // Make sure not to fetch deleted appointments
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while fetching appointment with ID: {id}");
                throw new Exception($"Error occurred while fetching appointment with ID: {id}", ex);
            }
        }

        public async Task<int> UpdateAsync(Appointment appointment)
        {
            try
            {
                 context.appointments.Update(appointment);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating appointment.");
                throw new Exception("Error occurred while updating appointment.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var appointment = await context.appointments.FindAsync(id);
                if (appointment != null)
                {
                    appointment.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occurred while deleting appointment with ID: {id}");
                throw new Exception($"Error occurred while deleting appointment with ID: {id}", ex);
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
