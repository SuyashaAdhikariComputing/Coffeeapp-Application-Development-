using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;
using Coffeeapp.Data.Utils;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Coffeeapp.Data.Services
{

    public class OrderService
    {
        
        private static void SaveAll(string Phone, List<OrderItems> Order)
        {
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string OrderFilePath = Utils.GetCustomerFilePath(string Phone);

            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }

            var json = JsonSerializer.Serialize(Order);
            File.WriteAllText(OrderFilePath, json);
        }

        private static void SaveAll(Guid OrderId, List<OrderItems> Order)
        {
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string AllOrderFilePath = Utils.GetOrderFilePath();

            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }

            var json = JsonSerializer.Serialize(Order);
            File.WriteAllText(AllOrderFilePath, json);
        }

        private static void SaveAllUser(Guid OrderId, List<OrderItems> Order)
        {   
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string AllCustomerOrderFilePath = Utils.GetCustomerFilePath(string Phone);


            var json = JsonSerializer.Serialize(Order);
            File.WriteAllText(AllCustomerOrderFilePath, json);
        }

        public static List<OrderItems> GetAll()
        {
            string appOrderFilePath = Utils.GetOrderFilePath();
            if (!File.Exists(appOrderFilePath))
            {
                return new List<OrderItems>();
            }

            var json = File.ReadAllText(appOrderFilePath);

            return JsonSerializer.Deserialize <List<OrderItems>>(json);
        }

        public static List<OrderItems> GetAllCustomer()
        {
            string CustomerOrderFilePath = Utils.GetCustomerFilePath();
            if (!File.Exists(CustomerOrderFilePath))
            {
                return new List<OrderItems>();
            }

            var json = File.ReadAllText(CustomerOrderFilePath);

            return JsonSerializer.Deserialize<List<OrderItems>>(json);
        }

    }
}
