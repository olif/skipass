namespace SkiPass.Provider
{
    public class SkiPassService
    {
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

            // Check age and calculate rebate
            var discount = 0d;
            var age = Math.Floor((DateTime.Now - dateOfBirth).TotalDays / 365);

            if (age < 5)
                discount = 1;
            if (age < 15)
                discount = 0.3;
            if (age > 65)
                discount = 0.3;

            // Calculate price
            var price = Math.Round(Math.Floor((to - from).TotalDays) * 200 * (1d - discount));

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