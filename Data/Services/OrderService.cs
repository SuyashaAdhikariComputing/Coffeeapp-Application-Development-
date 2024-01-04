using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;



namespace Coffeeapp.Data.Services
{

    public class OrderService
    {
        private List<OrderItem> Order;
        private readonly string filePath = "Order.json";
        private int nextId = 1;

        public List<OrderItem> GetUser(string Phone)
        {
            if (Order == null)
            {
                // Handle the case where 'Order' is null
                return new List<OrderItem>();
            }

            return Order.Where(t => t.Phone == Phone).ToList();
        }

        public void AddOrder(string Phone, string Topping, string Coffee)
        {
            var newOrder = new OrderItem { Id = nextId++, Phone = Phone, Topping = Topping, Coffee = Coffee };
            Order.Add(newOrder);
            SaveOrder();
        }

        private void SaveOrder()
        {
            string json = JsonSerializer.Serialize(Order);
            File.WriteAllText(filePath, json);
        }

        private void LoadTodos()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                Order = JsonSerializer.Deserialize<List<OrderItem>>(json) ?? new List<OrderItem>();
            }
            catch (Exception)
            {
                Order = new List<OrderItem>();
            }
        }

    }
}
