using System.ComponentModel.DataAnnotations;

namespace api_bharat_lawns.DTO
{
    public class Register
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        public string? MobileNo { get; set; }
        [MinLength(6, ErrorMessage = "Enter minimum 6 character password")]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}