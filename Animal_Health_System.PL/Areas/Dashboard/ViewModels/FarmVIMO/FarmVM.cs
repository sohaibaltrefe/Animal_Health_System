using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO
{
    public class FarmVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string OwnerFullName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
