using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Model;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc; 


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepository _heroesRepository;

        public HeroesController(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        // GET api/heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> Get()
        {
            var heroes = await _heroesRepository.GetAllAsync();
            return Ok(heroes);
        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> Get(Guid id)
        {
            return Ok(await _heroesRepository.GetByIdAsync(id));
        }

        // POST api/heroes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hero hero)
        {
            if (hero.IsValid())
            {
                await _heroesRepository.AddAsync(hero);
                await _heroesRepository.SaveAsync();
                return CreatedAtAction("Get", new {id = hero.Id});
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/heroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Hero hero)
        {
            if (await _heroesRepository.GetByIdAsync(hero.Id) != null)
            {
                _heroesRepository.Update(hero);
                await _heroesRepository.SaveAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var hero = await _heroesRepository.GetByIdAsync(id);
            if (hero != null)
            {
                _heroesRepository.Delete(hero);
                await _heroesRepository.SaveAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
