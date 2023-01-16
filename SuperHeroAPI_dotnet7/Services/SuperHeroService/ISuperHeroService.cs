using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI_dotnet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero([FromBody] SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, [FromBody] SuperHero request);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
