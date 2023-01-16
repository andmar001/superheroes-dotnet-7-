using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_dotnet7.Data;
using SuperHeroAPI_dotnet7.Models;

namespace SuperHeroAPI_dotnet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>()
        {
            new SuperHero
            {
                Id=1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place="New York"
            },
            new SuperHero
            {
                Id=2,
                Name="Punisher",
                FirstName="Frank",
                LastName="Castle",
                Place="Texas"
            },
            new SuperHero
            {
                Id=3,
                Name="Iron Main",
                FirstName="Tony",
                LastName="Stark",
                Place="Las Vegas"
            }
        };

        //inyección de datacontex
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }
        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null)
                return null;
            
            return hero;
        }
        public async Task<List<SuperHero>> AddHero([FromBody] SuperHero hero)
        {   
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>?> UpdateHero(int id, [FromBody] SuperHero request)
        {
            //search id 
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
