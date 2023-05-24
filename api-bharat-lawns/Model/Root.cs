using System;
using System.ComponentModel.DataAnnotations;

namespace api_bharat_lawns.Model
{
    public class Root
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedById { get; set; }
        public string? UpdatedById { get; set; }
    }
}

