using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_bharat_lawns.CustomeValidation;

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

        [RequiredNum]
        public int FunctionTypeId { get; set; }

        public FunctionType? FunctionTypes { get; set; }

        public Invoice? Invoice { get; set; }




    }

    public enum MealType
    {
        Veg,
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

