using System;
using System.ComponentModel.DataAnnotations;
using api_bharat_lawns.CustomeValidation;
using api_bharat_lawns.Model;

namespace api_bharat_lawns.ViewModel
{
    public class BookingDTO
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Please enter Name")]
        public string Name { get; set; }
        [DateValidate(ErrorMessage = "Function date must be a date greater than or equal to the current date.")]
        public DateTime FunctionDate { get; set; }
        
        [Required(ErrorMessage ="Please enter a valid Mobile NO")][MobileNoAttribute(ErrorMessage ="Mobile No must be 10 digit")]
        public string MobileNo { get; set; }
        [RequiredNum (ErrorMessage ="Please enter Amount")]
        public decimal Amount { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }
        public int[]? FeatureIds { get; set; }
        [RequiredNum(ErrorMessage ="Please select Program Timing")]
        public int ProgramTypeId { get; set; }
        [Required (ErrorMessage ="Please select Meal Type")]
        public MealType MealType { get; set; }
        [RequiredNum(ErrorMessage ="Please select Function Type")]
        public int FunctionTypeId { get; set; }
        public Status Status { get; set; } = 0;

    }
}

