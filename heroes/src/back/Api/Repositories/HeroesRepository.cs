using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Infrastructure;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class HeroesRepository : IHeroesRepository
    {
        private readonly HeroesContext _context;

        public HeroesRepository(HeroesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await _context.Heroes.ToListAsync();
        }

        public async Task<Hero> GetByIdAsync(Guid id)
        {
            return await _context.Heroes.SingleOrDefaultAsync(h => h.Id == id);
        }

        public void Update(Hero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;
            
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(Hero hero)
        {
            _context.Heroes.Remove(hero);
        }

        public async Task AddAsync(Hero hero)
        {
            await _context.AddAsync(hero);
        }
    }
} 
