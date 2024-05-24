using System;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

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