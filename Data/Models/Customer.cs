using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{

    public class Customer
    {
        public Guid CustomerID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int OrderCount { get; set; } = 0;

        public string Phone { get; set; }
        public string Address { get; set; }
        
        
    }
}