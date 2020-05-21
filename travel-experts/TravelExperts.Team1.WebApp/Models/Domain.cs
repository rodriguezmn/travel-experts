using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TravelExperts.Team1.WebApp.Data;

namespace TravelExperts.Team1.WebApp.Models
{
    public class Domain
    {

        public class User
        {
            //public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            //public string Role { get; set; }
        }


        /// <summary>
        /// Class is responsible for authenticating and managing users.
        /// </summary>
        public class UserManager
        {
            private readonly static List<User> _users;

            //static UserManager()
            //{
            //    _users = new List<User>();
               
            //    _users.Add(new User
            //    {
            //        Id = 1,
            //        Username = "jdoe",
            //        Password = "password",
            //        FullName = "John Doe",
            //        Role = "Manager"
            //    });
            //    _users.Add(new User
            //    {
            //        Id = 2,
            //        Username = "khunter",
            //        Password = "password",
            //        FullName = "Karen Hunter",
            //        Role = "Staff"
            //    });
            //}

            internal static object Authenticate(object userName, string password)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// User is authenticated based on credentials and a user returned if exists or null if not.
            /// </summary>
            /// <param name = "username" > Username as string </ param >
            /// <param name="password">Password as string</param>
            /// <returns>A user object or null.</returns>
            /// <remarks>
            /// Add additional for the docs for this application--for developers.
            /// </remarks>
            public static User Authenticate(string username, string password)
            {
                //var user = _users.SingleOrDefault(usr => usr.Username == username
                //                                        && usr.Password == password);

                // return user object from database of user where username and password match
                var context = new TravelExpertsContext();
                var customer = context.Customers.SingleOrDefault(cus => cus.Username == username
                                                                     && cus.Password == password);

                var user = context.Customers.Where(cus => cus.Username == username && cus.Password == password)
                                              .Select(cus => new User()
                                              {
                                                  Username = cus.Username,
                                                  Password = cus.Password,
                                                  Name = cus.CustFirstName
                                              }).SingleOrDefault();

                

                //// decompose object and create a User (based on class up here)

                //if (customer != null)
                //{
                //    var user = new User();
                //    //List<User> user = new List<User>();
                //    user.Name = customer.CustFirstName;
                //    user.Username = customer.Username;
                //    user.Password = customer.Password;
                //}


            return user; //this will either be null or an object
            }
        }
    }
}
