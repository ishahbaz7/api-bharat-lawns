using System.ComponentModel.DataAnnotations;

namespace api_bharat_lawns.Controllers
{
    public class UpdatePassword
    {
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your New Password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Please enter your Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}