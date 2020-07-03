using System;

namespace Shared.Support.ClassExtensions
{
    public static  class DateTimeExtension
    {
        public static int CalculateBirthDate(this DateTime birthdate)
        {
            // Save today's date.
            DateTime today = DateTime.Today;

            // Calculate the age.
            int age = today.Year - birthdate.Year;

            // Go back to the year the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
