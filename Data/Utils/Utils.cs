using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Utils
{
    public static class Utils
    {
        public static string GetAppDirectoryPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Bislerium"
            );
        }

        public static string GetOrderFilePath()
        {
            return Path.Combine(GetAppDirectoryPath(), "order.json");
        }

        public static string GetCustomerFilePath(string Phone)
        {
            return Path.Combine(GetAppDirectoryPath(), Phone.ToString() + "_order.json");
        }

    }
}
