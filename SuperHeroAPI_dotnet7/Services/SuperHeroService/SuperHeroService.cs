using Microsoft.AspNetCore.Mvc;
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

        public List<SuperHero>? GetAllHeroes()
        {
            return superHeroes;
        }
        public SuperHero? GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);

            if (hero == null)
            {
                throw new Exception("Sorry, but this hero doesn´t exist");
            }

            return hero;
        }
        public List<SuperHero> AddHero([FromBody] SuperHero hero)
        {   
            superHeroes.Add(hero);
            return superHeroes;
        }
        public List<SuperHero>? UpdateHero(int id, [FromBody] SuperHero request)
        {
            //search id 
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
            {
                throw new Exception("Sorry, but this hero doesn´t exist");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return superHeroes;
        }
        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
            {
                throw new Exception("Sorry, but this hero doesn´t exist");
            }
            superHeroes.Remove(hero);
            return superHeroes;
        }
    }
}
