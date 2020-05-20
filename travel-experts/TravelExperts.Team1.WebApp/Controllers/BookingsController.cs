using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
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

        // Karim: To be revisted
        //public List<Bookings> GetAllByBCustomerId(int id)
        //{
        //    var context = new TravelExpertsContext();
        //    var listOfBookingDetails = context.BookingDetails.
        //    Include(b => b.Booking).
        //    Where(cid => cid.CustomerId == id);
        //    return listOfBookingDetails.ToList();
        //}

        public ActionResult Index()
        {
            var customerBookings = GetAllBookingDetails();
            var viewModels = customerBookings.Select(a => new BookingsModel
            {
                BookingId = Convert.ToInt32(a.BookingId),
                CustomerId = Convert.ToInt32(a.Booking.CustomerId),
              
                ItineraryNo =a.ItineraryNo,
                TripStart = a.TripStart,
                TripEnd = a.TripEnd,
                Destination = a.Destination,
                BasePrice = a.BasePrice,
                AgencyCommission=a.AgencyCommission,
                Description=a.Description,
                TotalPrice= a.BasePrice + a.AgencyCommission

            }).ToList();
            return View(viewModels);
        }
      

        } 
    }
