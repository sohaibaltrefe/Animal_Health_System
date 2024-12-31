using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO
{
    public class AnimalHealthHistoryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string AnimalName { get; set; }

        public DateTime? CreatedAt { get; set; }


    }
}

