using Xunit;
using System;

namespace SkiPass.Api.Tests {

    public class SkiPassPriceCalculatorTests {

        private static SkiPassPriceCalculator sut = new();
        public decimal priceForOneDay = sut.Calculate(new DateTime(2021, 01, 01), new DateTime(2021, 01, 01), new DateTime(1984, 06, 22));
        
        [Fact]
        public void RidersBelow15ShouldGetDiscount() {
            Assert.Equal(200, priceForOneDay);
        }
    }
}