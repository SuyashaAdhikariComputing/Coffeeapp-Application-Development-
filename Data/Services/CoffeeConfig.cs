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
        //private readonly list of the coffee 
        private readonly List<Coffee> _Listofcoffee = new()
        {
            new() { CoffeeName = "Flat White", Price = 190.0 },
            new() { CoffeeName = "Latte", Price = 120.0 },
            new() { CoffeeName = "Espresso", Price = 120.0 },
            new() { CoffeeName = "Americano", Price = 140.0 },
            new() { CoffeeName = "Ice Americano", Price = 180.0 },
            new() { CoffeeName = "Caramel Macchiato", Price = 200.0 },
            new() { CoffeeName = "Mocha", Price = 160.0 },
            new() { CoffeeName = "Drip Coffee", Price = 200.0 },
            new() { CoffeeName = "Frappuccino", Price = 220.0 },
            new() { CoffeeName = "Black Coffee", Price = 110.0 },
            new() { CoffeeName = "Decaf", Price = 240.0 }
        };

        //this method saves the coffe details to the json file
        public void SaveListofcoffeeInJsonFile(List<Coffee> coffeeList)
        {
            string DirPath = Utils.GetDirectoryPath();//gets the directory path
            string ListcoffeeFilePath = Utils.GetListedCofeeFilePath();//get coffee list file path

            if (!Directory.Exists(DirPath))//checks if directory exists
            {
                Directory.CreateDirectory(DirPath);
            }

            var json = JsonSerializer.Serialize(coffeeList);

            File.WriteAllText(ListcoffeeFilePath, json);//write the content to json file
        }

        // this method is used to get all the content of coffee file
        public List<Coffee> GetAllCoffeeFromJsonFile()
        {
            string ListcoffeeFilePath = Utils.GetListedCofeeFilePath();

            if (!File.Exists(ListcoffeeFilePath))// if file path do not exist it return empty list
            {
                return new List<Coffee>();
            }

            var json = File.ReadAllText(ListcoffeeFilePath);

            return JsonSerializer.Deserialize<List<Coffee>>(json);//change the json content to list
        }

        //this file is executed for the first time
        public void SeedCofeeDetails()
        {
            List<Coffee> coffeeList = GetAllCoffeeFromJsonFile();

            if (coffeeList.Count == 0)
            {
                SaveListofcoffeeInJsonFile(_Listofcoffee);
            }
        }

        // this method is used to get the coffee by the id
        public Coffee GetCofeeByID(String ID)
        {
            List<Coffee> coffeeList = GetAllCoffeeFromJsonFile();
            Coffee coffee = coffeeList.FirstOrDefault(coffee => coffee.Id.ToString() == ID);
            return coffee;
        }

        // this method is used to update the details
        public void UpdateDetails(Coffee coffee)
        {
            List<Coffee> coffeeList = GetAllCoffeeFromJsonFile();// get the coffee file path

            Coffee coffeeUpdate = coffeeList.FirstOrDefault(_coffee => _coffee.Id.ToString() == coffee.Id.ToString());

            if (coffeeUpdate == null)// if coffee not exist
            {
                throw new Exception("Coffee not found");
            }

            coffeeUpdate.CoffeeName = coffee.CoffeeName;
            coffeeUpdate.Price = coffee.Price;

            SaveListofcoffeeInJsonFile(coffeeList);//Calling save method
        }

       
    }
}
