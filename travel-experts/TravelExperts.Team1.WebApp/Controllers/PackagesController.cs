using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelExperts.Team1.WebApp.Managers;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Controllers
{
    public class PackagesController : Controller
    {
        public ActionResult Index()
        {
            var packages = PackageManager.GetAllPackages();
            return View(packages);
        }
        public ActionResult CurrentPackages()
                {
            List<Packages> listOfPackages = null;
            listOfPackages = PackageManager.GetAllCurrent();


            var packages = listOfPackages.Select(a => new PackagesViewModel
            {
                PackageId = a.PackageId,
                PkgName = a.PkgName,
                PkgStartDate = a.PkgStartDate,
                PkgEndDate = a.PkgEndDate,
                PkgDesc = a.PkgDesc,
                PkgBasePrice = a.PkgBasePrice,
                PkgAgencyCommission = a.PkgAgencyCommission,
                PkgTotalPrice = a.PkgBasePrice + Convert.ToDecimal(a.PkgAgencyCommission),
                PkgImage = a.PkgImage,
            }).ToList();

            return View(packages);
        }

    }
}