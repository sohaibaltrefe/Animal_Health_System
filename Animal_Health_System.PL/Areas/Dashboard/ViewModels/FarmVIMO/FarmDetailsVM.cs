using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO
{
    public class FarmDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string OwnerFullName { get; set; }
        public IEnumerable<Animal> Animals { get; set; }
    }
}
