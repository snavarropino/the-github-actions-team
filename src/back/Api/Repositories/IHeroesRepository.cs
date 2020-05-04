using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Model;

namespace Api.Repositories
{
    public interface IHeroesRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero> GetByIdAsync(Guid id);
        void Update(Hero hero);
        Task SaveAsync();
        Task AddAsync(Hero hero);
        void Delete(Hero hero);
    }
}