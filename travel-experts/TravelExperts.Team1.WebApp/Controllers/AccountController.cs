using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelExperts.Team1.WebApp.Models;
using static TravelExperts.Team1.WebApp.Models.Domain;

namespace TravelExperts.Team1.WebApp.Controllers
{
    // Marlon Rodriguez
    //  Programmed controller to manage the authentication process

    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            // authenticate using the manager

            var usr = UserManager.Authenticate(user.Username, user.Password);

            // return if user object is returned

            if (usr == null) 
                return View();

            //otherwise set up claims--one for each fact about the user 

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usr.Username),
                new Claim("FullName", usr.Name),
                new Claim(ClaimTypes.Sid, usr.Id.ToString())
            };

            //create the instance of Claimsldentity (holds the claims)
            
            var claimsldentity = new ClaimsIdentity(claims, "Cookies");

            //The signin creates the ClaimsPrincipal and cookie' 

            var claimsPrincipal = new ClaimsPrincipal(claimsldentity);

            await HttpContext.SignInAsync("Cookies", claimsPrincipal); 

            //handle the return url value from TempData if it exists or not 

            if (TempData["ReturnUrl"] == null)
                return RedirectToAction("Index", "Bookings"); 
            else 
                return Redirect(TempData["ReturnUrl"].ToString()); 
        }

        // log out user, delete cookie
        
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login", "Account");
        }

        // handle AccessDenied method call 
        // when user is not authorized even though authenticated

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}