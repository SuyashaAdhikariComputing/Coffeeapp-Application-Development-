using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffeeapp.Data.Models;
using Coffeeapp.Data.Enums;

namespace Coffeeapp.Data.Services
{
    public class LoginService
    {
        //defining the User Role
        private List<User> _seedUsersList = new()
        {
            new User()
            {
                Password = "admin",
                Role = Role.Admin,
            },

            new User()
            {
                Password = "staff",
                Role = Role.Staff
            }
        };


        //this method checks if password is valid and assign role according to the password
        public User CheckUser(String Password)
        {
            User user = _seedUsersList.FirstOrDefault(_user => _user.Password == Password);

            if (user == null)
            {
                throw new Exception("Incorrect Password");

            }
            return user;

        }
    }
}
