using RestApiAnimals.Model;

namespace RestApiAnimals;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    void AddAnimal(Animal animal);
    void UpdateAnimal(int animalId, Animal animal);
    void DeleteAnimal(int animalId);
}