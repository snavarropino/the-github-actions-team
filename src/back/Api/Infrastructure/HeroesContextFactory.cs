using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infrastructure
{
   public class HeroesContextFactory : IDesignTimeDbContextFactory<HeroesContext>
   {
       private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Heroes;Trusted_Connection=True;";

       public HeroesContext CreateDbContext(string[] args)
       {
           var optionsBuilder = new DbContextOptionsBuilder<HeroesContext>();
           optionsBuilder.UseSqlServer(ConnectionString);

           return new HeroesContext(optionsBuilder.Options);
       }
   }
}