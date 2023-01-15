using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI_dotnet7.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Apellido Paterno")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Apellido Materno")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Lugar")]
        public string Place { get; set; } = string.Empty;
    }
}
