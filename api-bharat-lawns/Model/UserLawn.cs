using System;
using api_bharat_lawns.CustomeValidation;

namespace api_bharat_lawns.Model
{
    public class UserLawn
    {
        public int Id { get; set; }
        [RequiredNum]
        public string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        [RequiredNum]
        public string LawnId { get; set; }
        public Lawn? Lawn { get; set; }
    }
}

