using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Services
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
            return Path.Combine(GetAppDirectoryPath(), "users.json");
        }

        public static string GetCustomerFilePath(int Id)
        {
            return Path.Combine(GetAppDirectoryPath(), Id.ToString() + "_todos.json");
        }
    }

}

