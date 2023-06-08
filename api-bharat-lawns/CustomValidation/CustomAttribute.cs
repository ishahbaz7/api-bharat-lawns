using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api_bharat_lawns.CustomeValidation
{
    public class DateValidate : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime.Date >= DateTime.Today;
        }

    }
    public class RequiredNum : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            int getal;
            if (int.TryParse(value.ToString(), out getal))
            {

                if (getal == 0)
                    return false;

                if (getal > 0)
                    return true;
            }
            return false;

        }
    }

    public class MobileNoAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }
            string mobileNumber = value.ToString();

            // Regular expression to validate Indian mobile number without country code
            var regex = new Regex(@"^[6-9]\d{9}$");

            return string.IsNullOrEmpty(mobileNumber) ? true : regex.IsMatch(mobileNumber);
        }
    }
}

