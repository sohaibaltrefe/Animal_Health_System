using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly ApplicationDbContext context;

        public VaccineRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(Vaccine vaccine)
        {
            try
            {
                await context.vaccines.AddAsync(vaccine);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while adding the vaccine", ex);
            }
        }

        public async Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            try
            {
                return await context.vaccines.Include(m => m.MedicalRecord)
                                             .Include(v => v.Veterinarian )
                                             .AsNoTracking()
                                             .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving vaccines", ex);
            }
        }

        public async Task<Vaccine> GetAsync(int id)
        {
            try
            {
                return await context.vaccines.Include(m => m.MedicalRecord )
                                             .Include(v => v.Veterinarian )
                                             .FirstOrDefaultAsync(ve => ve.Id == id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while retrieving the vaccine with ID {id}", ex);
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
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while updating the vaccine", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var vaccine = await context.vaccines.FindAsync(id);
                if (vaccine != null)
                {
                    vaccine.IsDeleted = true; // Soft delete
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while deleting the vaccine with ID {id}", ex);
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
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while saving changes", ex);
            }
        }
    }
}
