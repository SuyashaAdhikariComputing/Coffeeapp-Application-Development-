using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Coffeeapp.Data.Models
{

    //this is the model for SaveModel and its attributes are Customerphone, OrderContents

    public class SaveModel
    {
        public string Customerphone { get; set; }
        public List<OrderContent> OrderContents { get; set; }
    }
}
