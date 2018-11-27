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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            ExploreEntities1 db = new ExploreEntities1();
            ViewBag.tourists_count = db.AspNetUsers.Where(x => x.Type == "0").ToList().Count;
            ViewBag.tourguide_count = db.AspNetUsers.Where(x => x.Type == "1").ToList().Count;
            ViewBag.places_count = db.AllPackages.ToList().Count;
            return View();
        }

        public ActionResult Touristlist()
        {
            ExploreEntities1 db = new ExploreEntities1();
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
            ExploreEntities1 db = new ExploreEntities1();
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
            ExploreEntities1 db = new ExploreEntities1();
            var item = db.AspNetUsers.Where(x => x.Id == id).SingleOrDefault();
            db.AspNetUsers.Remove(item);
            db.SaveChanges();

            return RedirectToAction("TourGuidelist");
        }

        public ActionResult Packagelist()
        {
            ExploreEntities1 db = new ExploreEntities1();
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
            ExploreEntities1 db = new ExploreEntities1();

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

       


        [HttpPost]
        public ActionResult AddPackages(AllPackageViewModel collection)
        {

            try
            {
                ExploreEntities1 db = new ExploreEntities1();
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
                db.AllPackages.Add(p);

                db.SaveChanges();

                return RedirectToAction("dashboard", "Admin");
            }
            catch
            {
                return View();
            }

        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ExploreEntities1 ent = new ExploreEntities1();
                var list = ent.AllPackages.Where(x => x.PackageId == id).First();
                var d = ent.AllPackages.ToList();
                foreach(var i in d)
                {
                    if(i.PackageId == Convert.ToInt32(list))
                    {
                        ent.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                    
                
                ent.SaveChanges();
                return RedirectToAction("Admin", "Packagelist");
            }
            catch
            {
                return View();
            }
        }
    }

}