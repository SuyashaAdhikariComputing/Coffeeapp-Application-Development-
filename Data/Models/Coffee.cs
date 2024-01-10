using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeeapp.Data.Models
{
    // this is the model for coffee and its attributes are Id, CoffeeName and Price
    public class Coffee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CoffeeName { get; set; }
        public double Price { get; set; }
    }
}

