using System.ComponentModel.DataAnnotations;
using api_bharat_lawns.CustomeValidation;

namespace api_bharat_lawns.Model
{
    public class Feature : Root
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter feature name")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [RequiredNum]
        public decimal Price { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}