using System.ComponentModel.DataAnnotations;

namespace RestApiAnimals.Model
{
    
    public class Animal
    {
        [Required]
        public int idAnimal { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string area { get; set; }

    }
}
