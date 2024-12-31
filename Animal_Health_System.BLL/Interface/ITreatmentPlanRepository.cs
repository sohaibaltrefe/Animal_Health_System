using Animal_Health_System.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.BLL.Interface
{
    public interface ITreatmentPlanRepository
    {
        Task<IEnumerable<TreatmentPlan>> GetAllAsync();
        Task<TreatmentPlan> GetAsync(int id);
        Task<int> AddAsync(TreatmentPlan  treatmentPlan);
        Task<int> UpdateAsync(TreatmentPlan  treatmentPlan);

        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
