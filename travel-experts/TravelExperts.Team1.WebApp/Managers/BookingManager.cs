using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Managers
{
    public class BookingManager
    {
        public static List<BookingDetails> GetAllBookingDetails()
        {
            var context = new TravelExpertsContext();
            var listOfBookingDetails = context.BookingDetails.Include(b => b.Booking);
            return listOfBookingDetails.ToList();
        }

        public static List<BookingDetails> GetAllByBookingId(int id)
        {
            var context = new TravelExpertsContext();
            var filteredList = context.BookingDetails.
                Where(bid => bid.BookingId == id).
                Include(b => b.Booking).ToList();
            return filteredList;
        }

        public static List<BookingDetails> GetAllByBCustomerId(int id)
        {
            var context = new TravelExpertsContext();
            var listOfBookingDetails = context.BookingDetails.
            Include(b => b.Booking).
            Where(c => c.Booking.CustomerId == id);
            return listOfBookingDetails.ToList();
        }

        // Marlon Rodriguez
        //  Programmed method to get logged in user id from database
        // Irada moved to BookingManager to be also used by Customer Controller
        public static int GetUserId(string userName)
        {
            var context = new TravelExpertsContext();
            int userId = context.Customers.Where(u => u.Username == userName).
                                           Select(u => u.CustomerId).FirstOrDefault();
            return userId;
        }
        // Irada - added a manager for FirstName grabber
        public static string GetUserName(string userName)
        {
            var context = new TravelExpertsContext();
            string userFirstName = context.Customers.Where(u => u.Username == userName).
                                           Select(u => u.CustFirstName).FirstOrDefault();
            return userFirstName;
        }
    }
}
