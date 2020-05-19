using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Controllers
{
    public class BookingsController : Controller
    {
        public static List<BookingDetails> GetAllBookingDetails()
        {
            var context = new TravelExpertsContext();
            var listOfBookingDetails = context.BookingDetails.Include(b => b.Booking);
            return listOfBookingDetails.ToList();
        }

        public List<BookingDetails> GetAllByBookingId(int id)
        {
            var context = new TravelExpertsContext();
            var filteredList = context.BookingDetails.
                Where(bid => bid.BookingId == id).
                Include(b => b.Booking).ToList();
            return filteredList;
        }

        public ActionResult Index()
        {
            var customerBookings = GetAllBookingDetails();
            var viewModels = customerBookings.Select(a => new BookingsModel
            {
                BookingId = Convert.ToInt32(a.BookingId),
                CustomerId = Convert.ToInt32(a.Booking.CustomerId),
                TripStart = a.TripStart,
                TripEnd = a.TripEnd,
                BasePrice = a.BasePrice,
                Description = a.Description,

            }).ToList();
            return View(viewModels);
        }
    }
}