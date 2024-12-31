using Animal_Health_System.DAL.Models;


namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalVIMO
{
    public class AnimalVM
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public HealthStatus CurrentHealthStatus { get; set; }
        public string FarmName { get; set; }
    }
    }
