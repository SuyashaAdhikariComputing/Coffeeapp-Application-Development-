using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;


namespace Coffeeapp.Data.Services
{
    public class CoffeeConfig
    {
        private readonly List<Coffee> _Listofcoffee = new()
        {
            new() { CoffeeName = "Cappuccino", Price = 150.0 },
            new() { CoffeeName = "Latte", Price = 170.0 },
            new() { CoffeeName = "Espresso", Price = 120.0 },
            new() { CoffeeName = "Americano", Price = 140.0 },
            new() { CoffeeName = "Mocha", Price = 180.0 },
            new() { CoffeeName = "Macchiato", Price = 160.0 },
            new() { CoffeeName = "Flat White", Price = 160.0 },
            new() { CoffeeName = "Affogato", Price = 200.0 },
            new() { CoffeeName = "Irish Coffee", Price = 190.0 },
            new() { CoffeeName = "Turkish Coffee", Price = 130.0 },
            new() { CoffeeName = "Ristretto", Price = 110.0 }
        };

        public void SaveListofcoffeeInJsonFile(List<Coffee> coffeeList)
        {
            string DirPath = Utils.GetDirectoryPath();
            string ListcoffeeFilePath = Utils.GetListedCofeeFilePath();

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            var json = JsonSerializer.Serialize(coffeeList);

            File.WriteAllText(ListcoffeeFilePath, json);
        }

        public List<Coffee> GetAllCoffeeFromJsonFile()
        {
            string ListcoffeeFilePath = Utils.GetListedCofeeFilePath();

            if (!File.Exists(ListcoffeeFilePath))
            {
                return new List<Coffee>();
            }

            var json = File.ReadAllText(ListcoffeeFilePath);

            return JsonSerializer.Deserialize<List<Coffee>>(json);
        }

        public void SeedCofeeDetails()
        {
            List<Coffee> coffeeList = GetAllCoffeeFromJsonFile();

            if (coffeeList.Count == 0)
            {
                SaveListofcoffeeInJsonFile(_Listofcoffee);
            }
        }

        public Coffee GetCofeeByID(String ID)
        {
            List<Coffee> coffeeList = GetAllCoffeeFromJsonFile();
            Coffee coffee = coffeeList.FirstOrDefault(coffee => coffee.Id.ToString() == ID);
            return coffee;
        }

        public void UpdateCofeeDetails(Coffee coffee)
        {
            List<Coffee> coffeeList = GetAllCoffeeFromJsonFile();

            Coffee coffeeUpdate = coffeeList.FirstOrDefault(_coffee => _coffee.Id.ToString() == coffee.Id.ToString());

            if (coffeeUpdate == null)
            {
                throw new Exception("Coffee not found");
            }

            coffeeUpdate.CoffeeName = coffee.CoffeeName;
            coffeeUpdate.Price = coffee.Price;

            SaveListofcoffeeInJsonFile(coffeeList);
        }
    }
}
