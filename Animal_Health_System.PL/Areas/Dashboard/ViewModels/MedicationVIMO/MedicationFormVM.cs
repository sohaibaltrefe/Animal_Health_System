using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.MedicationVIMO
{
    public class MedicationFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Quantity { get; set; }
        public int? MedicalExaminationId { get; set; }


    }
}
