using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Services
{
    internal class Utils
    {

        public static string GetDirectoryPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }


        public static string GetListedCofeeFilePath()
        {
            return Path.Combine(GetDirectoryPath(), "Listcoffee.json");
        }

        public static string GetCustomerPath(string phone)
        {
            string fileName = $"customer_{phone}.json";
            return Path.Combine(GetDirectoryPath(), fileName);
        }

        //getting the JSON Path for Adins
        public static string GetAddInListPath()
        {
            return Path.Combine(GetDirectoryPath(), "Addinslist.json");
        }
        public static string GetOrderPath()
        {
            return Path.Combine(GetDirectoryPath(), "orders.json");
        }

    }
}
