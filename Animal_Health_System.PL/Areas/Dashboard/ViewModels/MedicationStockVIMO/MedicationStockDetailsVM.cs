using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationStockVIMO
{
    public class MedicationStockDetailsVM
    {
        public int Id { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime LastUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
