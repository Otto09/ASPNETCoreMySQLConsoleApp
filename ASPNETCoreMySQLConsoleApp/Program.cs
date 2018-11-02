using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace ASPNETCoreMySQLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using (var context = new animal_ownersContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds an animal
                var animal = new Animal
                {
                    Name = "Lion"
                };
                context.Animal.Add(animal);

                // Adds some clients
                context.Owner.Add(new Owner
                {
                    Id = 10,
                    Name = "Peter",
                    Number = 1,
                    Value = 20000,
                    AnimalId = 1,
                    Animal = animal
                });
                context.Owner.Add(new Owner
                {
                    Id = 11,
                    Name = "Mark",
                    Number = 2,
                    Value = 40000,
                    AnimalId = 1,
                    Animal = animal
                });
                context.Owner.Add(new Owner
                {
                    Id = 12,
                    Name = "Joe",
                    Number = 5,
                    Value = 100000,
                    AnimalId = 1,
                    Animal = animal
                });


                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            // Gets and prints all clients in database
            using (var context = new animal_ownersContext())
            {
                var owners = context.Owner
                  .Include(p => p.Animal);
                foreach (var owner in owners)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {owner.Id}");
                    data.AppendLine($"Name: {owner.Name}");
                    data.AppendLine($"Number: {owner.Number}");
                    data.AppendLine($"Value: {owner.Value}");
                    data.AppendLine($"AnimalId: {owner.AnimalId}");
                    data.AppendLine($"Name: {owner.Animal.Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
