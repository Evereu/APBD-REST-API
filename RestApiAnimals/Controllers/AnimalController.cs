using Microsoft.AspNetCore.Mvc;
using RestApiAnimals.Model;
using RestApiAnimals.Services;

namespace RestApiAnimals.Controllers
{
    
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)   
        {
            _animalService = animalService;   
        }

        [HttpGet("api/animal/{orderBy}")]
        public IActionResult GetAnimals(string orderBy = "Name")
        {
                var animals =  _animalService.GetAnimals(orderBy);
            
                return Ok(animals);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _animalService.AddAnimal(animal);
            
            return Ok($"Dodano Animal poprawnie - {animal.name}");
        }

        [HttpPut("{id:int}")]   
        public IActionResult UpdateAnimal(int id, Animal animal)
        {   
            _animalService.UpdateAnimal(id, animal);
            
            return Ok($"Obiekt Animal zaktualizowany id = {id} name = {animal.name}");  
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalService.DeleteAnimal(id);
            
            return Ok($"Usunięto obiekt animal id = {id}");
        }
    }
}
