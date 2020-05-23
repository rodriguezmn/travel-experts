using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExperts.Team1.WebApp.Managers;

using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Controllers
{
    public class BookingsController : Controller
    {
        //Marlon Rodriguez
        // Added authorization anotation to limit access to booking details
        // to authorized users only

        [Authorize]
        public ActionResult Index()
        {

            // Marlon Rodriguez
            //  Called method to get CustomerId from Customers table

            int userId = BookingManager.GetUserId(User.Identity.Name);
            
            // Irada Shamilova
            // Created BookingViewModel & this Controller to join 2 tables Booking and Booking Details that can now be filtered by CustomerID

            var customerBookings = BookingManager.GetAllByBCustomerId(userId);
            var viewModels = customerBookings.Select(a => new BookingsViewModel
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


            // Marlon Rodriguez
            //  Get bookings total

            decimal? total = customerBookings.Select(t => t.BasePrice + t.AgencyCommission).Sum();

            ViewBag.bookingsTotal = $"{total:N0}";



            return View(viewModels);
        }


        
    } 
    }
