using System.ComponentModel.DataAnnotations;

namespace BankingApp.WEB.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Enter login")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        [Display(Name = "Enter password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}