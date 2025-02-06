﻿using Animal_Health_System.BLL.Interface;
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
    public class MatingRepository : IMatingRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<MatingRepository> logger;

        public MatingRepository(ApplicationDbContext context, ILogger<MatingRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> AddAsync(Mating  mating)
        {
            try
            {
                await context.matings.AddAsync(mating);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding mating.");
                throw new Exception("Error occurred while adding mating.", ex);
            }
        }

        public async Task<IEnumerable<Mating>> GetAllAsync()
        {
            try
            {
                return await context.matings.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving matings.");
                throw new Exception("Error occurred while retrieving matings.", ex);
            }
        }

        public async Task<Mating> GetAsync(int id)
        {
            try
            {
                return await context.matings
                    
                    .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving mating.");
                throw new Exception("Error occurred while retrieving mating.", ex);
            }
        }

        public async Task<int> UpdateAsync(Mating mating)
        {
            try
            {
                context.matings.Update(mating);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating mating.");
                throw new Exception("Error occurred while updating mating.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var mating = await context.matings.FindAsync(id);
                if (mating != null)
                {
                    mating.IsDeleted = true;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting mating.");
                throw new Exception("Error occurred while deleting mating.", ex);
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
