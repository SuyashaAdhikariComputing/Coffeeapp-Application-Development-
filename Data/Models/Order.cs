﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{
    public class Order
    {
        
      
        public DateTime OrderDate { get; set; } 

        //public string TotalPrice { get; set; }

        public List<OrderContent> OrderContents { get; set; }
    }
}
