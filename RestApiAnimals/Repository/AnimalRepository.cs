using System.Data.SqlClient;
using RestApiAnimals.Model;

namespace RestApiAnimals;

public class AnimalRepository : IAnimalRepository
{
     public IEnumerable<Animal> GetAnimals()
     {                    
          var animals = new List<Animal>();

          using (var connection = new SqlConnection(@"Server=MICHO\SQLEXPRESS;Database=APBD;Trusted_Connection=True"))
          {
               connection.Open();

               using (var command = new SqlCommand())
               {
                    command.Connection = connection;

                    command.CommandText = "SELECT IdAnimal,Name, Description, Category, Area FROM [dbo].[Animal]";

                    var dr = command.ExecuteReader();
                    
                    while (dr.Read())
                    {
                         var animal = new Animal
                         {
                              idAnimal = (int)dr["IdAnimal"],
                              name = dr["Name"].ToString(),
                              description = dr["Description"].ToString(),
                              category = dr["Category"].ToString(),
                              area = dr["Area"].ToString()
                         };
                         animals.Add(animal);
                    }
               }
          }

          return animals;
     }


     public void AddAnimal(Animal animal)
     {
          using (var connection = new SqlConnection(@"Server=MICHO\SQLEXPRESS;Database=APBD;Trusted_Connection=True"))
          {
               connection.Open();

               using (var command = new SqlCommand())
               {
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO [dbo].[Animal] (idAnimal, name, description, category, area) VALUES (@idAnimal, @name, @description, @category, @area)";

                    command.Parameters.AddWithValue("@idAnimal", animal.idAnimal);
                    command.Parameters.AddWithValue("@name", animal.name);
                    command.Parameters.AddWithValue("@description", animal.description);
                    command.Parameters.AddWithValue("@category", animal.category);
                    command.Parameters.AddWithValue("@area", animal.area);
                    
                    var dr = command.ExecuteReader();
               }
          }
     }

     
     public void UpdateAnimal(int animalId, Animal animal)
     {
          using (var connection = new SqlConnection(@"Server=MICHO\SQLEXPRESS;Database=APBD;Trusted_Connection=True"))
          {
               connection.Open();

               using (var command = new SqlCommand())
               {
                    command.Connection = connection;

                    command.CommandText = "UPDATE [dbo].[Animal] SET name = @name, description = @description, category = @category, area = @area WHERE IdAnimal = @animalId";

                    command.Parameters.AddWithValue("@animalId", animalId);
                    command.Parameters.AddWithValue("@name", animal.name);
                    command.Parameters.AddWithValue("@description", animal.description);
                    command.Parameters.AddWithValue("@category", animal.category);
                    command.Parameters.AddWithValue("@area", animal.area);

                    
                    var dr = command.ExecuteReader();
               }
          }
     }

     public void DeleteAnimal(int animalId)
     {
          using (var connection = new SqlConnection(@"Server=MICHO\SQLEXPRESS;Database=APBD;Trusted_Connection=True"))
          {
               connection.Open();

               using (var command = new SqlCommand())
               {
                    command.Connection = connection;

                    command.CommandText = "DELETE FROM [dbo].[Animal] WHERE IdAnimal = @animalId";

                    command.Parameters.AddWithValue("@animalId", animalId);
                    
                    var dr = command.ExecuteReader();
               }
          }
     }
     
     
     
     


}