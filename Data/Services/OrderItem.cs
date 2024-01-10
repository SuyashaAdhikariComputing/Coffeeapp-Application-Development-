
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;
using Microsoft.AspNetCore.Components;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static MudBlazor.CategoryTypes;



namespace Coffeeapp.Data.Services
{
    public class OrderItem
    {
        //this method is used for adding item to order content
        public void AddItem(List<OrderContent> _orderContent, Guid itemID, String ItemType, Double Price, string name)
        {
            OrderContent ordercontent = _orderContent.FirstOrDefault(x => x.ItemID == itemID && x.ItemType == ItemType);

            if (ordercontent != null)
            {
                //increase the quantity value if already exist
                ordercontent.Quantity++;
                //update the price of the value if added again
                ordercontent.TotalPrice = ordercontent.Quantity * Price;
                return;
            }

            ordercontent = new()
            {
                Name = name,
                ItemID = itemID,
                ItemType = ItemType,
                Quantity = 1,
                Price = Price,
                TotalPrice = Price,
                
            };
            //add the item in the list
            _orderContent.Add(ordercontent);


        }

        //this method is used for deleting the item in the order content
        public void DeleteItemInList(List<OrderContent> _orderContent, Guid orderContentID)
        {
            OrderContent orderContent = _orderContent.FirstOrDefault(x => x.OrderContentID == orderContentID);

            if (orderContent != null)
            {
                _orderContent.Remove(orderContent);
            }
        }


        //This method is used to configure the quantity of item
        public void QuantityOfItem(List<OrderContent> _orderContent, Guid orderContentID, String action)
        {
            OrderContent orderContent = _orderContent.FirstOrDefault(x => x.OrderContentID == orderContentID);

            if (orderContent != null)
            {
                if (action == "add")
                {
                    orderContent.Quantity++;
                    orderContent.TotalPrice = orderContent.Quantity * orderContent.Price;
                }
                //decrease the quantity by 1
                else if (action == "sub" && orderContent.Quantity > 1)
                {
                    orderContent.Quantity--;
                    orderContent.TotalPrice = orderContent.Quantity * orderContent.Price;
                }
                //remove the item if quantity is 0
                else if (action == "sub" && orderContent.Quantity == 1)
                {
                    _orderContent.Remove(orderContent);
                }
            }
        }

      //this method is used to save order to order Json file
        public void SavenewOrder(List<OrderContent> orderContents,string phone)
        {
            try
            {
                string orderFilePath = Utils.GetOrderPath();
                List<SaveModel> existingOrders = new List<SaveModel>();

                if (File.Exists(orderFilePath))
                {
                    string existingData = File.ReadAllText(orderFilePath);

                    if (!string.IsNullOrWhiteSpace(existingData))
                    {
                        // Deserialize existing orders
                        existingOrders = JsonSerializer.Deserialize<List<SaveModel>>(existingData);
                    }
                }

                SaveModel newOrder = new SaveModel
                {
                    Customerphone =phone,
                    OrderContents = orderContents
                };

                existingOrders.Add(newOrder);

                // Write the updated orders back to the file
                var json = JsonSerializer.Serialize(existingOrders);
                File.WriteAllText(orderFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving order data to JSON: {ex.Message}");
            }
        }

        //this method is used to save the order to the customer file
        public void SaveOrderToCustomerJson(string phone, List<OrderContent> orderContents)
        {
            try
            {
                string orderFilePath = Utils.GetCustomerPath(phone);

                List<Order> existingOrders = new List<Order>();

                // Read existing orders from the file, if any
                if (File.Exists(orderFilePath))
                {
                    string existingData = File.ReadAllText(orderFilePath);

                    if (!string.IsNullOrWhiteSpace(existingData))
                    {
                        // Deserialize existing orders
                        existingOrders = JsonSerializer.Deserialize<List<Order>>(existingData);
                    }
                }

                int numberOfItems = existingOrders.Count;

                if (numberOfItems == 10)//changes counter to 0 if it reaches 10
                {
                    numberOfItems = 0;
                }

                // Create a new order
                Order newOrder = new Order
                {
                    OrderDate= DateTime.Now,
                    counter=numberOfItems+1,
                    OrderContents = orderContents
                };

                // Add the new order
                existingOrders.Add(newOrder);

                // Write the updated orders back to the file
                var json = JsonSerializer.Serialize(existingOrders);
                File.WriteAllText(orderFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving order data to JSON: {ex.Message}");
            }
        }

        // this is used to get the order from the order file 
        public List<SaveModel> GetOrders()
        {
            string orderFilePath = Utils.GetOrderPath();
            if (File.Exists(orderFilePath))
            {
                string jsonData = File.ReadAllText(orderFilePath);
                return JsonSerializer.Deserialize<List<SaveModel>>(jsonData) ?? new List<SaveModel>();
            }
            return new List<SaveModel>();
        }

        //this is used to get the last order from the customer file and check the counter of the order
        public int GetLastOrderCounter(string phone)
        {
            try
            {
                string orderFilePath = Utils.GetCustomerPath(phone);

                if (File.Exists(orderFilePath))
                {
                    string existingData = File.ReadAllText(orderFilePath);

                    if (!string.IsNullOrWhiteSpace(existingData))
                    {
                        List<Order> existingOrders = JsonSerializer.Deserialize<List<Order>>(existingData);

                        // Check if there are any existing orders
                        if (existingOrders.Any())
                        {
                            // Get the last order and return its counter value
                            Order lastOrder = existingOrders.Last();
                            return lastOrder.counter;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting last order counter from JSON: {ex.Message}");
            }

            // Return a default value if there is an error or no existing orders
            return 0;
        }
    }
}

