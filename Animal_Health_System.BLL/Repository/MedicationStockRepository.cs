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
    public class MedicationStockRepository : IMedicationStockRepository
    {
        private readonly ApplicationDbContext context;

        public MedicationStockRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(MedicationStock  medicationStock)
        {

         
           
            await context.medicationStocks.AddAsync(medicationStock);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicationStock>> GetAllAsync()
        {
            return await context.medicationStocks.Include(m=>m.Medications).ToListAsync();
        }

        public async Task<MedicationStock> GetAsync(int id)
        {
            return await context.medicationStocks
                    .Include(m => m.Medications)
                    .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> UpdateAsync(MedicationStock  medicationStock)
        {
            context.medicationStocks.Update(medicationStock);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var MedicationStock = await context.medicationStocks.FindAsync(id);
            if (MedicationStock != null)
            {
                MedicationStock.IsDeleted = true; // Soft delete
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
