using System.ComponentModel.DataAnnotations;
using api_bharat_lawns.CustomeValidation;

namespace api_bharat_lawns.DTO
{
    public class UpdateUser
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your User Name")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address")]
        public string Email { get; set; }
        [MobileNoAttribute(ErrorMessage = "Please enter a valid Mobile Number")]
        public string? PhoneNumber { get; set; }
    }
}