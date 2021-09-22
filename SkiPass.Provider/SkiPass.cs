namespace SkiPass.Provider
{
    public class SkiPass
    {
        public Guid ID { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

    }
}
