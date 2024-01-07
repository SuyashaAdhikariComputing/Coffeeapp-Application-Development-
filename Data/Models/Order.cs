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
        public DateTime OrderDate { get; set; }
        public String EmployeeName { get; set; }
        public DateTime OrderTime { get; set; }
        public Customer Customer { get; set; }

    }
}
