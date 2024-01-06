
using System.Text.Json;
using Coffeeapp.Data.Models;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Coffeeapp.Data.Services
{
    public class Order
    {
        private static void SaveAll(int Id, List<OrderModel> Orders)
        {
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string UserFilePath = Utils.GetCustomerFilePath(Id);

            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }

            var json = JsonSerializer.Serialize(Orders);
            File.WriteAllText(UserFilePath, json);
        }

        public static List<OrderModel> GetAll(int Id)
        {
            string CustomerFilePath = Utils.GetCustomerFilePath(Id);
            if (!File.Exists(CustomerFilePath))
            {
                return new List<OrderModel>();
            }

            var json = File.ReadAllText(CustomerFilePath);

            return JsonSerializer.Deserialize<List<OrderModel>>(json);
        }

        public  List<OrderModel> Create(string Coffee, string Topping, int Id)
        {
            
            List<OrderModel> Order = GetAll(Id);
            Order.Add(new OrderModel
            {
                Coffee = Coffee, 
                Topping = Topping,
                Id = Id
            });
            SaveAll(Id,Order );
            return Order;
        }

    }
}
