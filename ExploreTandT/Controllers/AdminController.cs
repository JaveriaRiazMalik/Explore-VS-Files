using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class AdminController : Controller
    {
        ExploreEntities db = new ExploreEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            
            ViewBag.tourists_count = db.AspNetUsers.Where(x => x.Type == "0").ToList().Count;
            ViewBag.tourguide_count = db.AspNetUsers.Where(x => x.Type == "1").ToList().Count;
            ViewBag.places_count = db.AllPackages.ToList().Count;
            return View();
        }

        public ActionResult Touristlist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (AspNetUser u in db.AspNetUsers)
            {
                if (u.Type == "0")
                {
                    user.listoftourists.Add(u);
                }
            }
            return View(user);
        }

        public ActionResult TourGuidelist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (AspNetUser u in db.AspNetUsers)
            {
                if (u.Type == "1")
                {
                    user.listoftourguide.Add(u);
                }
            }
            return View(user);
        }

        public ActionResult DeleteTourGuide(string id)
        {
            var item = db.AspNetUsers.Where(x => x.Id == id).SingleOrDefault();
            db.AspNetUsers.Remove(item);
            db.SaveChanges();

            return RedirectToAction("TourGuidelist");
        }

        public ActionResult DeleteTourist(string id)
        {
            ExploreEntities db = new ExploreEntities();
            var item = db.AspNetUsers.Where(x => x.Id == id).SingleOrDefault();
            db.AspNetUsers.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Touristlist");
        }

        public ActionResult Packagelist()
        {
            AdminViewModel user = new AdminViewModel();
            List<AllPackageViewModel> l = new List<AllPackageViewModel>();
            var packageslist = db.AllPackages.ToList();
            if (packageslist != null)
            {
                foreach (var p in packageslist)
                {
                    AllPackageViewModel allpack = new AllPackageViewModel();
                    allpack.packageId = p.PackageId;
                    allpack.Name = p.Name;
                    allpack.Category = p.Category;
                    allpack.Places = p.Places;
                    allpack.Range = Convert.ToInt16(p.Range);
                    allpack.TourGuide = p.TourGuide;
                    allpack.Schedule = p.Schedule;
                    allpack.Vehicle = p.Vehicle;
                    allpack.Hotel = p.Hotel;
                    allpack.Refreshments = p.Refreshments;

                    user.listofpackages.Add(allpack);

                }
            }
            return View(user);
        }

        public ActionResult AddPackages()
        {

            List<string> name = new List<string>();

            foreach (AspNetUser u in db.AspNetUsers)
            {
                if (u.Type == "1")
                {
                    name.Add(u.Name);

                }
            }

            ViewBag.name = name;
            return View();
        }

       public ActionResult DeletePackage(int id)
        {
            var item = db.AllPackages.Where(x => x.PackageId == id).SingleOrDefault();
            db.AllPackages.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Packagelist");
        }

        [HttpPost]
        public ActionResult AddPackages(AllPackageViewModel collection)
        {

            try
            {
 
                AllPackage p = new AllPackage();

                p.Name = collection.Name;
                p.Category = collection.Category;
                p.Places = collection.Places;
                p.Range = collection.Range;
                p.TourGuide = collection.TourGuide;

                p.Schedule = collection.Schedule;
                p.Vehicle = collection.Vehicle;
                p.Hotel = collection.Hotel;
                p.Refreshments = collection.Refreshments;
                if (p.Name != null && p.Schedule != null && p.Places != null && p.Range != 0 && p.Refreshments != null && p.TourGuide != null && p.Vehicle != null)
                {
                    db.AllPackages.Add(p);

                    db.SaveChanges();
                    return RedirectToAction("dashboard", "Admin");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        
    }

}