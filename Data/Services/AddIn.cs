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
        //this is the readonly list of the coffee add ins
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

        //this method is used for saving the addins data
        public void SaveAddInData(List<CoffeeAddIn> CoffeeAddInList)
        {
            string DirPath = Utils.GetDirectoryPath(); ;//getting the directory path
            string addInItemsFilePath = Utils.GetAddInListPath();//getting the path of addin json file

            if (!Directory.Exists(DirPath))//checks if directory exists
            {
                Directory.CreateDirectory(DirPath);
            }

            var json = JsonSerializer.Serialize(CoffeeAddInList);//serialize the data

            File.WriteAllText(addInItemsFilePath, json);//write to json file
        }

        //this method is used to get the addins data from json
        public List<CoffeeAddIn> GetAllAddIns()
        {
            string addInItemsFilePath = Utils.GetAddInListPath();//getting the path of addin json file

            if (!File.Exists(addInItemsFilePath))// if file dont exists it return empty list
            {
                return new List<CoffeeAddIn>();
            }

            var json = File.ReadAllText(addInItemsFilePath);// read content of file

            return JsonSerializer.Deserialize<List<CoffeeAddIn>>(json);//convert the json to list
        }

        //this method is used one time to store the content of readonly least to json file
        public void SeedAddInItems()
        {
            List<CoffeeAddIn> ListofAddIn = GetAllAddIns();

            if (ListofAddIn.Count == 0)
            {
                SaveAddInData(_CoffeeAddIn);
            }
        }

        //this is used to get the addin item by id
        public CoffeeAddIn GetAddInItemByID(String addInItemID)
        {
            List<CoffeeAddIn> AddIns = GetAllAddIns();
            CoffeeAddIn addInItem = AddIns.FirstOrDefault(addIn => addIn.Id.ToString() == addInItemID);
            return addInItem;
        }

        //this is used for updating the addin json contents
        public void UpdateAddIn(CoffeeAddIn coffeeAddIn)
        {
            List<CoffeeAddIn> addInItemsList = GetAllAddIns();//get all addin data in json file

            CoffeeAddIn addInItemToUpdate = addInItemsList.FirstOrDefault(_addInItem => _addInItem.Id.ToString() == coffeeAddIn.Id.ToString());

            if (addInItemToUpdate == null)//if no add in item is founf
            {
                throw new Exception("Add-In item not found");
            }

            addInItemToUpdate.Name = coffeeAddIn.Name;
            addInItemToUpdate.Price = coffeeAddIn.Price;

            SaveAddInData(addInItemsList);
        }
    }
}
