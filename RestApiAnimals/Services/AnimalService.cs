using RestApiAnimals.Model;

namespace RestApiAnimals.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(String orderedColumn) 
    {   
        var animals = _animalRepository.GetAnimals(orderedColumn);

        return animals;

    }

    public void AddAnimal(Animal animal)
    {
        _animalRepository.AddAnimal(animal);
    }

    public void UpdateAnimal(int animalId, Animal animal)
    {
        _animalRepository.UpdateAnimal(animalId, animal);
    }

    public void DeleteAnimal(int animalId)
    {
        _animalRepository.DeleteAnimal(animalId);
    }
}