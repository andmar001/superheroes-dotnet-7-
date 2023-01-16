global using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI_dotnet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-TONYMON;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true");
        } 
        public DbSet<SuperHero>SuperHeroes{ get; set; }
    }
}
