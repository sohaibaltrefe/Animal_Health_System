using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    public class MedicationRepository: IMedicationRepository
    {
        private readonly ApplicationDbContext context;

        public MedicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(Medication medication)
        {
            await context.medications.AddAsync(medication);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            return await context.medications.AsNoTracking().ToListAsync();
        }

        public async Task<Medication> GetAsync(int id)
        {
            return await context.medications.FindAsync(id);
        }

        public async Task<int> UpdateAsync(Medication medication)
        {
            context.medications.Update(medication);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medication = await context.medications.FindAsync(id);
            if (medication != null)
            {
                medication.IsDeleted = true; // Soft delete
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
