using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Services
{
    internal class Utils
    {

        //used for getting the directory path
        public static string GetDirectoryPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        //used for getting the coffee path
        public static string GetListedCofeeFilePath()
        {
            return Path.Combine(GetDirectoryPath(), "Listcoffee.json");
        }

        //used for getting the customer path
        public static string GetCustomerPath(string phone)
        {
            string fileName = $"customer_{phone}.json";
            return Path.Combine(GetDirectoryPath(), fileName);
        }

        //used for getting the addin path
        public static string GetAddInListPath()
        {
            return Path.Combine(GetDirectoryPath(), "Addinslist.json");
        }

        //used for getting orderpath
        public static string GetOrderPath()
        {
            return Path.Combine(GetDirectoryPath(), "orders.json");
        }

        

    }
}
