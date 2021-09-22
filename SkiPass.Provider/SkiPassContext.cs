using Microsoft.EntityFrameworkCore;

namespace SkiPass.Provider
{
    public class SkiPassContext : DbContext
    {
        public DbSet<SkiPass> Passes { get; set; }

        public SkiPassContext()
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=InMemorySample;Mode=Memory;Cache=Shared");

        public override void Dispose()
        {
            Database.CloseConnection();
            base.Dispose();
        }
    }
}
