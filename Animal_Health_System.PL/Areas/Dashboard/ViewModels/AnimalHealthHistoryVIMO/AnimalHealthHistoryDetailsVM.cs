using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.AnimalHealthHistoryVIMO
{
    public class AnimalHealthHistoryDetailsVM
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string AnimalName { get; set; }

        public string MedicalRecordName { get; set; }


        public DateTime? UpdatedAt { get; set; }



    }
}
