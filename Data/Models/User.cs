using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffeeapp.Data.Enums;

namespace Coffeeapp.Data.Models
{

    //this is the model for User and its attributes are Password and Role
    public class User
    {
       
        public string Password { get; set; }

        public Role Role { get; set; }

        

    }
}


