using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_bharat_lawns.CustomeValidation;
using AutoMapper.Features;

namespace api_bharat_lawns.Model
{
    public class Booking : Root
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Function date is required")]
        public DateTime FunctionDate { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        public string MobileNo { get; set; }

        public string? OtherFeatures { get; set; }

        [Required(ErrorMessage = "Meal type is required")]
        public MealType MealType { get; set; }

        public Status Status { get; set; } = Status.Active;
        public DateTime? CancellationDate { get; set; }

        [RequiredNum]
        public int FunctionTypeId { get; set; }
        [RequiredNum]
        public FunctionType? FunctionTypes { get; set; }
        public int ProgramTypeId { get; set; }
        public ProgramType? ProgramTypes { get; set; }
        public List<Feature>? Features { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [RequiredNum]
        public decimal Amount { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }
        public int InvoiceNo { get; set; }
        [RequiredNum]
        public int  InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }




    }

    public enum MealType
    {
        Veg = 1,
        NonVeg
    }

    public enum Status
    {
        Active = 1,
        Cancelled,
        Done,
        Pending
    }

}

