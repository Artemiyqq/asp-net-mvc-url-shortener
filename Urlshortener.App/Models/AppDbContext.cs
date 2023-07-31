using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; } = null!;

        private readonly string? connectionSettings;

        public AppDbContext(string schema = "public")
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            connectionSettings = configuration.GetConnectionString("DefaultConnection") + schema;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionSettings);
        }
    }
}