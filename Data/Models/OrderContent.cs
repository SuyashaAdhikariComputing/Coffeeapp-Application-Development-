﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{

    public class OrderContent
    {
        public Guid OrderContentID { get; set; } = Guid.NewGuid();
        public Guid OrderID { get; set; }
        public Guid ItemID { get; set; }
        public string Name { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
