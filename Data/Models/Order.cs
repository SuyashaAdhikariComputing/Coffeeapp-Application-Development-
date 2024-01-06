using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{

    public class OrderItems
    {
        public Guid OrderId { get; set; }
        public string Coffee { get; set; }
        public string Topping { get; set; }

        public string Phone { get; set; }
    }
}

