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

        [HttpGet]
        public IActionResult GetAnimals(string orderBy)
        {
           var animals =  _animalService.GetAnimals();
            
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _animalService.AddAnimal(animal);
            
            return Ok("AddAnimal");
        }

        [HttpPut("{id:int}")]   
        public IActionResult UpdateAnimal(int id, Animal animal)
        {   
            _animalService.UpdateAnimal(id, animal);
            
            return Ok("UpdateAnimal");  
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalService.DeleteAnimal(id);
            
            return Ok("DeleteAnimal");
        }
    }
}
