using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Coffeeapp.Data.Models
{
    // this is the model for order and its attributes are OrderDate, counter and ordercontents
    public class Order
    {
        
      
        public DateTime OrderDate { get; set; }

        //public string TotalPrice { get; set; }

        public int counter { get; set; }
        public List<OrderContent> OrderContents { get; set; }

       
    }
}
