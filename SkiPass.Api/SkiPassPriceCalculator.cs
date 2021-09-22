using System;

namespace SkiPass.Api 
{
    public class SkiPassPriceCalculator {
        public decimal Calculate(DateTime from, DateTime to, DateTime dateOfBirth) {

            // Check age and calculate discount
            var ageDiscount = 0d;
            var age = Math.Floor((DateTime.Now - dateOfBirth).TotalDays / 365);

            if (age < 5)
                ageDiscount = 1;
            if (age < 15)
                ageDiscount = 0.3;
            if (age > 65)
                ageDiscount = 0.3;

            // Calculate price
            var days = Math.Floor((to - from).TotalDays);
            var price = 0d;
            price += Math.Round(Math.Min(days, 20) * 200 * (1d - ageDiscount));
            price += Math.Round(Math.Clamp(days - 20, 0, 10) * 200 * (1d - ageDiscount) * 0.5);

            // Add early bird discount for season price
            if (days > 30 && DateTime.Now < new DateTime(DateTime.Now.Year, 11, 1))
                price *= 0.85;

            return Convert.ToDecimal(price);
        }
    }
}