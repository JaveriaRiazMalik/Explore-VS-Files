using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class TourController : Controller
    {
        ExploreEntities db = new ExploreEntities();
        // GET: Tour
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllPackages()
        {
            return View();
        }
        public ActionResult AdminAccount()
        {
            ViewBag.Tourists = db.AspNetUsers.Where(x => x.Type == "0").ToList();
            ViewBag.Tourists = db.AspNetUsers.Where(x => x.Type == "1").ToList();
            ViewBag.Places = db.AspNetUsers.ToList();
            return View();
        }
        public ActionResult AddPackage()
        {
            return View();
        }
        public ActionResult GetPackage()
        {
            return View();
        }
        public ActionResult PackageConfirmation()
        {
            return View();
        }
        public ActionResult RelatedPackages()
        {
            return View();
        }
        public ActionResult TermsandConditions()
        {
            return View();
        }
        public ActionResult TourGuideAccount()
        {
            return View();
        }
        public ActionResult TouristAccount()
        {
            return View();
        }
    }
}