using RestApiAnimals.Model;

namespace RestApiAnimals.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderedColumn);
    void AddAnimal(Animal animal);  
    void UpdateAnimal(int animalId, Animal animal);
    void DeleteAnimal(int animalId);
}