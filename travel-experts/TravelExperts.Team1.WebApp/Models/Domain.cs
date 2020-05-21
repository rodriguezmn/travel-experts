using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TravelExperts.Team1.WebApp.Data;

namespace TravelExperts.Team1.WebApp.Models
{
    // Marlon Rodriguez
    //  Created domain model to use for user login

    public class Domain
    {

        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
        }

        // Marlon Rodriguez 
        //  Programmed class responsible for authenticating and managing users
        public class UserManager
        {
            public static User Authenticate(string username, string password)
            {
                var context = new TravelExpertsContext();
                var customer = context.Customers.SingleOrDefault(cus => cus.Username == username
                                                                     && cus.Password == password);

                var user = context.Customers.Where(cus => cus.Username == username && cus.Password == password)
                                              .Select(cus => new User()
                                              {
                                                  Id = cus.CustomerId,
                                                  Username = cus.Username,
                                                  Name = cus.CustFirstName
                                              }).SingleOrDefault();

            return user;
            }
        }
    }
}
