using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.VaccineVIMO
{
    public class VaccineVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public DateTime AdministrationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string VeterinarianName { get; set; }
    }
}
