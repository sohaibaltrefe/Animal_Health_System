using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineVIMO
{
    public class VaccineDetailsVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public DateTime AdministrationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string VeterinarianName { get; set; }
        public string MedicalRecordDetails { get; set; } // Display relevant details of the medical record if necessary

        // Related data (e.g., vaccine histories)
        public ICollection<VaccineHistory> VaccineHistories { get; set; } = new HashSet<VaccineHistory>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
