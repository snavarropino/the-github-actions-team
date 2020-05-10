using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure
{
    public class HeroesContext: DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options)
        : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
    }
}
