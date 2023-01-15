using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_dotnet7.Models;

namespace SuperHeroAPI_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var superHeroes = new List<SuperHero>()
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
                }
            };
            return Ok(superHeroes);
        }
    }
}
