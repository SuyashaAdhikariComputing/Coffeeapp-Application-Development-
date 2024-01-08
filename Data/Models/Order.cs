using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{
    public class Order
    {
        
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; } 

        public string TotalPrice { get; set; }

        
    }
}
