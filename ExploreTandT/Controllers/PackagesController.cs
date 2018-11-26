using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class PackagesController : Controller
    {
        

        public ActionResult Index()
        {
            ExploreEntities1 db = new ExploreEntities1();
            AdminViewModel userL = new AdminViewModel();
            var list = db.AllPackages.ToList();
            List<AllPackageViewModel> x = new List<AllPackageViewModel>();
            
            foreach (var i in list)
            {
                AllPackageViewModel v = new AllPackageViewModel();
                v.Category = i.Category;
                v.Name = i.Name;
                v.Places = i.Places;
                v.Range = Convert.ToInt16(i.Range);
                v.TourGuide = i.TourGuide;
                v.Schedule = i.Schedule;
                v.Vehicle = i.Vehicle;
                v.Hotel = i.Hotel;
                v.Refreshments = i.Refreshments;
                v.packageId = i.PackageId;

                userL.listofpackages.Add(v);
            }

            return View(userL);
        }

        // GET: Packages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packages/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Packages/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Packages/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
