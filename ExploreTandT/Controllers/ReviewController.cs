using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Show the Reviews to all users 
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowReview()
        {

            ExploreEntities d = new ExploreEntities();
            var storeReviews = d.Reviews.ToList();
            ShowReviewModel userl = new ShowReviewModel();

            foreach (var t in storeReviews)
            {
                ReviewsModel r = new ReviewsModel();
                r.Name = t.Name;
                r.Reviews = t.Reviews;
                userl.StoreReview.Add(r);

            }
            return View(userl);
        }
    }
}
