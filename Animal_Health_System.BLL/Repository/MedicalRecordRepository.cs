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
    public class MedicalRecordRepository: IMedicalRecordRepository
    {
        private readonly ApplicationDbContext context;

        public MedicalRecordRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(MedicalRecord medicalRecord)
        {
            // التحقق إذا كان للحيوان سجل طبي
            var existingRecord = await context.medicalRecords
                .FirstOrDefaultAsync(mr => mr.AnimalId == medicalRecord.AnimalId && !mr.IsDeleted);

            if (existingRecord != null)
            {
                throw new InvalidOperationException("This animal already has a medical record.");
            }

            await context.medicalRecords.AddAsync(medicalRecord);
            var result = await context.SaveChangesAsync();

            // تعيين MedicalRecordId في Animal
            var animal = await context.animals.FindAsync(medicalRecord.AnimalId);
            if (animal != null)
            {
                animal.MedicalRecordId = medicalRecord.Id;
                context.animals.Update(animal);
                await context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<MedicalRecord> GetByAnimalIdAsync(int animalId)
        {
            return await context.medicalRecords
                                 .FirstOrDefaultAsync(mr => mr.AnimalId == animalId);
        }
        public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
        {
            return await context.medicalRecords
                .Include(m => m.Animal )      // تضمين الكائن Animal
                .ThenInclude(a => a.Farm )    // تضمين الكائن Farm داخل Animal
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MedicalRecord> GetAsync(int id)
        {
            return await context.medicalRecords
        .Include(m => m.Animal ).ThenInclude(a => a.Farm )
        .Include(m => m.Vaccines)
        .Include(m=>m.Examinations)
        .ThenInclude(m=>m.Medications)// Ensure this includes the Vaccines
        .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> UpdateAsync(MedicalRecord medicalRecord)
        {
            context.medicalRecords.Update(medicalRecord);
            var result = await context.SaveChangesAsync();

            // تعيين MedicalRecordId في Animal
            var animal = await context.animals.FindAsync(medicalRecord.AnimalId);
            if (animal != null)
            {
                animal.MedicalRecordId = medicalRecord.Id;
                context.animals.Update(animal);
                await context.SaveChangesAsync();
            }

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var medicalRecord = await context.medicalRecords.FindAsync(id);
            if (medicalRecord != null)
            {
                medicalRecord.IsDeleted = true; // Soft delete
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> AnyAsync(Func<MedicalRecord, bool> predicate)
        {
            return await Task.FromResult(context.medicalRecords.Any(predicate));
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
