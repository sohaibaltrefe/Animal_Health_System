using Animal_Health_System.BLL.Interface;
using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Repository
{
    internal class PregnancyNotificationRepository : IPregnancyNotificationRepository
    {
        public Task<int> AddAsync(PregnancyNotification pregnancyNotification)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PregnancyNotification>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PregnancyNotification> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PregnancyNotification pregnancyNotification)
        {
            throw new NotImplementedException();
        }
    }
}
