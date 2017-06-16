using System.ComponentModel.DataAnnotations;

namespace BankingApp.WEB.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Enter login")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        [Display(Name = "Enter password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

        [Display(Name = "Confirm your password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}