using System;
using System.ComponentModel.DataAnnotations;

namespace api_bharat_lawns.Model
{
    public class Lawn
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

    }
}

