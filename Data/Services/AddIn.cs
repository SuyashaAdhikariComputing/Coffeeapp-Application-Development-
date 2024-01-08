using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;

namespace Coffeeapp.Data.Services
{
    public class AddIn
    {
        private readonly List<CoffeeAddIn> _CoffeeAddIn = new()
        {
            new() { Name = "Extra Sugar", Price = 10.0 },
            new() { Name = "Whipped Cream", Price = 15.0 },
            new() { Name = "Chocolate Syrup", Price = 10.0 },
            new() { Name = "Hazelnut Syrup", Price = 20.0 },
            new() { Name = "Caramel", Price = 15.0 },
            new() { Name = "Hazelnut Flavor", Price = 20.0 },
            new() { Name = "Choco chip", Price = 17.0 },
            new() { Name = "Vanilla Extract", Price = 30.0 },
            new() { Name = "Brown Sugar", Price = 50.0 },
            new() { Name = "Nutmeg", Price = 60.0 },
        };


        public void SaveAddInData(List<CoffeeAddIn> CoffeeAddInList)
        {
            string DirPath = Utils.GetDirectoryPath(); ;
            string addInItemsFilePath = Utils.GetAddInListPath();

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            var json = JsonSerializer.Serialize(CoffeeAddInList);

            File.WriteAllText(addInItemsFilePath, json);
        }

        public List<CoffeeAddIn> GetAllAddIns()
        {
            string addInItemsFilePath = Utils.GetAddInListPath();

            if (!File.Exists(addInItemsFilePath))
            {
                return new List<CoffeeAddIn>();
            }

            var json = File.ReadAllText(addInItemsFilePath);

            return JsonSerializer.Deserialize<List<CoffeeAddIn>>(json);
        }

        public void SeedAddInItems()
        {
            List<CoffeeAddIn> ListofAddIn = GetAllAddIns();

            if (ListofAddIn.Count == 0)
            {
                SaveAddInData(_CoffeeAddIn);
            }
        }

        public CoffeeAddIn GetAddInItemByID(String addInItemID)
        {
            List<CoffeeAddIn> AddIns = GetAllAddIns();
            CoffeeAddIn addInItem = AddIns.FirstOrDefault(addIn => addIn.Id.ToString() == addInItemID);
            return addInItem;
        }

        public void UpdateAddIn(CoffeeAddIn coffeeAddIn)
        {
            List<CoffeeAddIn> addInItemsList = GetAllAddIns();

            CoffeeAddIn addInItemToUpdate = addInItemsList.FirstOrDefault(_addInItem => _addInItem.Id.ToString() == coffeeAddIn.Id.ToString());

            if (addInItemToUpdate == null)
            {
                throw new Exception("Add-In item not found");
            }

            addInItemToUpdate.Name = coffeeAddIn.Name;
            addInItemToUpdate.Price = coffeeAddIn.Price;

            SaveAddInData(addInItemsList);
        }
    }
}
