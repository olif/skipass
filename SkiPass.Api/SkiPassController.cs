using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkiPass.Api
{
    public record SkiPassBookingDTO(
        [Required(AllowEmptyStrings = false)] string FirstName,
        [Required(AllowEmptyStrings = false)] string LastName,
        [Required] DateTime DateOfBirth,
        [Required] DateTime From,
        [Required] DateTime To) : IValidatableObject
    {

        private readonly DateTime seasonStart = new(2021, 05, 01);
        private readonly DateTime seasonEnd = new(2021, 05, 01);

        public string GetFullName() {
            return $"{FirstName} {LastName}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (From < seasonStart)
            {
                yield return new ValidationResult("from is specified before season start", new[] {nameof(From)});
            }
            if (To > seasonEnd)
            {
                yield return new ValidationResult("to is specified after season ends", new[] {nameof(To)});
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SkiPassController : ControllerBase
    {
        private readonly SkiPassRepository skiPassRepo;
        private readonly SkiPassPriceCalculator skiPassPriceCalculator;

        public SkiPassController(SkiPassRepository skiPassRepository, SkiPassPriceCalculator skiPassPriceCalculator)
        {
            this.skiPassRepo = skiPassRepository;
            this.skiPassPriceCalculator = skiPassPriceCalculator;
        }

        [HttpPost]
        public IActionResult OrderSkiPass([FromBody] SkiPassBookingDTO skiPassBooking)
        {
            var price = skiPassPriceCalculator.Calculate(skiPassBooking.From, skiPassBooking.To, skiPassBooking.DateOfBirth);

            var skiPass = new SkiPass()
            {
                Name = skiPassBooking.GetFullName(),
                Price = price,
                ValidFrom = skiPassBooking.From,
                ValidTo = skiPassBooking.To
            };

            skiPassRepo.CreatePass(skiPass);

            return Ok(skiPass);
        }
    }
}
