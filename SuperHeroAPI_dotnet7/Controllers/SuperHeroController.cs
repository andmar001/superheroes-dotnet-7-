using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_dotnet7.Models;
using SuperHeroAPI_dotnet7.Services.SuperHeroService;
using System.Threading.Tasks.Dataflow;

namespace SuperHeroAPI_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = _superHeroService.GetAllHeroes();
            if (result is null)
            {
                return NotFound("Heros not found");
            }
            return Ok(result);
        }

        //single hero
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = _superHeroService.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, [FromBody] SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id,request);
            if (result is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result);
        }
        
    }
}
