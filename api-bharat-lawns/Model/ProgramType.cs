using System;
using System.ComponentModel.DataAnnotations;

namespace api_bharat_lawns.Model
{
    public class ProgramType : Root
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter program name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter program start time")]
        public int NoOfHours { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter program price")]
        public decimal Price { get; set; }
    }
}

