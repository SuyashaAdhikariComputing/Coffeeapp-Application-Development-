using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{
    public class Order
    {
        public Guid OrderID { get; set; } = Guid.NewGuid();
        public Guid CustomerID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }

    }
}
