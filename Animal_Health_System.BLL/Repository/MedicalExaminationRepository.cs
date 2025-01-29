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
        public class MedicalExaminationRepository : IMedicalExaminationRepository

        {
            private readonly ApplicationDbContext context;

            public MedicalExaminationRepository(ApplicationDbContext context)
            {
                this.context = context;
            }

            

            public async Task<IEnumerable<MedicalExamination>> GetAllAsync()
            {
                return await context.medicalExaminations.AsNoTracking().ToListAsync();
            }

            public async Task<MedicalExamination> GetAsync(int id)
            {
            return await context.medicalExaminations.Include(me => me.Animals)
            .Include(me => me.MedicalRecords)
            .Include(me => me.Medications).Include(v => v.Veterinarians)
            .FirstOrDefaultAsync(me => me.Id == id);
            }

        public async Task<int> AddAsync(MedicalExamination medicalExamination)
        {
            await context.medicalExaminations.AddAsync(medicalExamination);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(MedicalExamination medicalExamination)
        {
            context.medicalExaminations.Update(medicalExamination);
            return await context.SaveChangesAsync();
        }
       

            public async Task DeleteAsync(int id)
            {
                var medicalExamination = await context.medicalExaminations.FindAsync(id);
                if (medicalExamination != null)
                {
                    medicalExamination.IsDeleted = true; // Soft delete
                    await context.SaveChangesAsync();
                }
            }

            public async Task SaveChangesAsync()
            {
                await context.SaveChangesAsync();
            }
        }
    }
