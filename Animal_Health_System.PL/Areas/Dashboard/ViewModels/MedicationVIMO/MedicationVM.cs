using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationVIMO
{
    public class MedicationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public DateTime ExpiryDate { get; set; }

       

    }
}
