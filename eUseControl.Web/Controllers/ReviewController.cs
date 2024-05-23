using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ISession _session;

        public ReviewController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var reviews = _session.GetAllReviews();
            var newReview = new Review();
            ViewBag.NewReview = newReview;
            return View(reviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(Review newReview)
        {
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                newReview.UserId = user.Id;
                newReview.DatePosted = DateTime.Now;

                _session.AddReview(newReview);

                return RedirectToAction("Index");
            }

            // Debugging code to see the validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
            }

            var reviews = _session.GetAllReviews();
            ViewBag.NewReview = newReview;
            return View("Index", reviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReview(int reviewId)
        {
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var review = _session.GetReviewById(reviewId);
            if (review != null && review.UserId == user.Id)
            {
                _session.DeleteReview(reviewId);
            }

            return RedirectToAction("Index");
        }
    }
}
