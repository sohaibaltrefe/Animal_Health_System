using System.ComponentModel.DataAnnotations;

namespace Animal_Health_System.PL.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email is Required ..")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
