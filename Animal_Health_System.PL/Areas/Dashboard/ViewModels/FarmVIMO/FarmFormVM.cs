using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.FarmVIMO
{
    public class FarmFormVM
    {
        public int Id { get; set; }
          [Required]
        public string Name { get; set; }
        [Required]

        public string Location { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Owner is required")]  
     
        public int? OwnerId { get; set; }
        public SelectList? Owners { get; set; }

    }
}
