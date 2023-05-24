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

        public decimal NetAmount { get; set; }

        public bool StageDecoration { get; set; }

        public bool Anjuman { get; set; }

        public bool Mandap { get; set; }

        public bool Entry { get; set; }

        public bool Chowrie { get; set; }

        public bool CateringService { get; set; }

        public string OtherFeatures { get; set; }

        //public ProgramTimings ProgramTimings { get; set; }

        public MealType MealType { get; set; }

        public Status Status { get; set; } = 0;

        public int FunctionTypeId { get; set; }

        public FunctionType FunctionTypes { get; set; }
    }
}

