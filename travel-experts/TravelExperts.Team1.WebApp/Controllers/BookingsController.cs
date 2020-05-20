using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExperts.Team1.WebApp.Managers;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Controllers
{
    public class BookingsController : Controller
    {
        
        public ActionResult Index()
        {
            var customerBookings = BookingManager.GetAllBookingDetails();
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
            return View(viewModels);
        }
      

        } 
    }
