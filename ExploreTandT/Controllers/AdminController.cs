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

        /// <summary>
        /// Show the details of all user and packages
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            
            ViewBag.tourists_count = db.AspNetUsers.Where(x => x.Type == "0").ToList().Count;
            ViewBag.tourguide_count = db.AspNetUsers.Where(x => x.Type == "1").ToList().Count;
            ViewBag.places_count = db.AllPackages.ToList().Count;
            return View();
        }

        /// <summary>
        /// Show the list of registered tourists 
        /// </summary>
        /// <returns></returns>
        public ActionResult Touristlist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (AspNetUser u in db.AspNetUsers)
            {
                if (u.Type == "0")// set their type
                {
                    user.listoftourists.Add(u);
                }
            }
            return View(user);
        }

        /// <summary>
        /// Show the list of registered tour guides
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Confirmation message to delete the tourist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteTourist(string id)
        {
            return View();
        }

        /// <summary>
        /// Delete the specific Tourist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>
        /// return the updated list
        /// </returns>
        // POST: Tourist/Delete/5
        [HttpPost]
        public ActionResult DeleteTourist(string id, FormCollection collection)
        {
            try
            {

                ExploreEntities db = new ExploreEntities();
                var item = db.AspNetUsers.Where(x => x.Id == id).SingleOrDefault();
                db.AspNetUsers.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Touristlist");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// show the list of all packages
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// show the add package view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPackages()
        {

            List<string> name = new List<string>();

            foreach (AspNetUser u in db.AspNetUsers)//dropdown list creation of Tour Guide
            {
                if (u.Type == "1")
                {
                    name.Add(u.Name);

                }
            }
            name.Sort();

            ViewBag.name = name;
            return View();
        }

        /// <summary>
        /// Add the packages in database
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
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
                    
                    return RedirectToAction("Dashboard","Admin");
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

        /// <summary>
        /// View the confirmation message 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: TourGuide/Delete/5
        public ActionResult DeleteT(string id)
        {
            return View();
        }

        /// <summary>
        /// Delete the specific Tour guide
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: TourGuide/Delete/5
        [HttpPost]
        public ActionResult DeleteT(string id, FormCollection collection)
        {
            try
            {
                var item = db.AspNetUsers.Where(x => x.Id == id).SingleOrDefault();
                db.AspNetUsers.Remove(item);
                db.SaveChanges();

                return RedirectToAction("TourGuidelist");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// View the confirnmation message 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Packages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Delete the specific Package
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Packages/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var item = db.AllPackages.Where(x => x.PackageId == id).SingleOrDefault();
                db.AllPackages.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Packagelist");
            }
            catch
            {
                return View();
            }
        }


    }

}