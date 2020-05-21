using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Managers
{
    public class PackageManager
    {
        public static List<Packages> GetAllPackages()
        {
            var context = new TravelExpertsContext();
            var packagesList = context.Packages;
            return packagesList.ToList();
        }

        public static List<Packages> GetAllCurrent()
        {
            var context = new TravelExpertsContext();
            var packagesList = context.Packages.
            Where(a => a.PkgStartDate > DateTime.Today); 
            return packagesList.ToList();
        }
    }
}
