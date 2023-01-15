using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI_dotnet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero>? GetAllHeroes();
        SuperHero? GetSingleHero(int id);
        List<SuperHero> AddHero([FromBody] SuperHero hero);
        List<SuperHero>? UpdateHero(int id, [FromBody] SuperHero request);
        List<SuperHero>? DeleteHero(int id);
    }
}
