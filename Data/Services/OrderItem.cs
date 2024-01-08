using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;

namespace Coffeeapp.Data.Services
{
    public class OrderItem
    {
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
                TotalPrice = Price
            };
            //add the item in the list
            _orderContent.Add(ordercontent);


        }

        public void DeleteItemInList(List<OrderContent> _orderContent, Guid orderContentID)
        {
            OrderContent orderContent = _orderContent.FirstOrDefault(x => x.OrderContentID == orderContentID);

            if (orderContent != null)
            {
                _orderContent.Remove(orderContent);
            }
        }

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
    }
}
