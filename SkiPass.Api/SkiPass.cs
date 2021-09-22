using System;

namespace SkiPass.Api
{
    public class SkiPass
    {
        public Guid ID { get; init; } = new Guid();
        public DateTime ValidFrom { get; init; }
        public DateTime ValidTo { get; init; }
        public string? Name { get; init; }
        public decimal Price { get; init; }

    }
}
