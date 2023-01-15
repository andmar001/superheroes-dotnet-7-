using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_dotnet7.Models;

namespace SuperHeroAPI_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
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

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        //single hero
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);

            if (hero == null)
            {
                return NotFound("Sorry, but this hero doesn´t exist");
            }

            return Ok(hero);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
            if (hero == null)
            {
                throw new Exception("El hero es obligatorio");
            }
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, [FromBody] SuperHero request)
        {
            //search id 
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero == null)
            {
                return NotFound("Sorry, but this hero doesn´t exist");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return Ok(superHeroes);
        }
    }
}
