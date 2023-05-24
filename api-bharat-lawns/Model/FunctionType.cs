using System;
using System.ComponentModel.DataAnnotations;

namespace api_bharat_lawns.Model
{
    public class FunctionType : Root
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

    }
}

