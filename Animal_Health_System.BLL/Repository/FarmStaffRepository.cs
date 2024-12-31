using Animal_Health_System.DAL;
using Animal_Health_System.DAL.Models;
using Animal_Health_System.BLL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_Health_System.DAL.Data;

namespace Animal_Health_System.BLL.Repository
{
    public class FarmStaffRepository : IFarmStaffRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FarmStaffRepository> _logger;

        public FarmStaffRepository(ApplicationDbContext context, ILogger<FarmStaffRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Add new FarmStaff
        public async Task<int> AddAsync(FarmStaff farmStaff)
        {
            try
            {
                farmStaff.CreatedAt = DateTime.Now;
                farmStaff.UpdatedAt = DateTime.Now;

                _context.farmStaff.Add(farmStaff);
                await _context.SaveChangesAsync();

                return farmStaff.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding farm staff.");
                throw new Exception("Error adding farm staff.", ex);
            }
        }

        // Delete FarmStaff (soft delete)
        public async Task DeleteAsync(int id)
        {
            try
            {
                var farmStaff = await _context.farmStaff.FindAsync(id);
                if (farmStaff != null)
                {
                    farmStaff.IsDeleted = true;
                    farmStaff.UpdatedAt = DateTime.Now;
                    _context.farmStaff.Update(farmStaff);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting farm staff.");
                throw new Exception("Error deleting farm staff.", ex);
            }
        }

        // Get all FarmStaff
        public async Task<IEnumerable<FarmStaff>> GetAllAsync()
        {
            try
            {
                return await _context.farmStaff
                                     .Where(f => !f.IsDeleted)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching farm staff.");
                throw new Exception("Error fetching farm staff.", ex);
            }
        }

        // Get FarmStaff by ID
        public async Task<FarmStaff> GetAsync(int id)
        {
            try
            {
                return await _context.farmStaff.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching farm staff by ID.");
                throw new Exception("Error fetching farm staff by ID.", ex);
            }
        }

        // Save Changes
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes.");
                throw new Exception("Error saving changes.", ex);
            }
        }

        // Update FarmStaff
        public async Task<int> UpdateAsync(FarmStaff farmStaff)
        {
            try
            {
                farmStaff.UpdatedAt = DateTime.Now;

                _context.farmStaff.Update(farmStaff);
                await _context.SaveChangesAsync();

                return farmStaff.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating farm staff.");
                throw new Exception("Error updating farm staff.", ex);
            }
        }
    }
}
    