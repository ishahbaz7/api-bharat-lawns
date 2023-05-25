using System;
using api_bharat_lawns.Model;

namespace api_bharat_lawns.ViewModel
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FunctionDate { get; set; }
        public string MobileNo { get; set; }
        public decimal Amount { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }
        public int[]? FeatureIds { get; set; }
        public int ProgramTypeId { get; set; }
        public MealType MealType { get; set; }
        public int FunctionTypeId { get; set; }
        public Status Status { get; set; } = 0;

    }
}

