using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkiPass.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkiPassController : ControllerBase
    {
        [HttpGet]
        public SkiPass OrderSkiPass(string firstName, string lastName, DateTime dateOfBirth, DateTime from, DateTime to)
        {
            // Check all input is valid
            ArgumentNullException.ThrowIfNull(firstName);
            ArgumentNullException.ThrowIfNull(lastName);

            // Check availability (after season start, to season end)
            if (from < new DateTime(2021, 11, 1))
                throw new ArgumentOutOfRangeException("from");
            if (to > new DateTime(2022, 05, 01))
                throw new ArgumentOutOfRangeException("to");

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
            

            var skiPass = new SkiPass()
            {
                Name = firstName + " " + lastName,
                Price = Convert.ToDecimal(price),
                ValidFrom = from,
                ValidTo = to
            };

            var skiPassRepository = new SkiPassRepository();
            skiPassRepository.CreatePass(skiPass);

            return skiPass;
        }
    }
}
