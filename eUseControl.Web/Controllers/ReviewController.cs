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
            var viewModel = new Tuple<IEnumerable<Review>, ReviewViewModel>(reviews, new ReviewViewModel());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(ReviewViewModel reviewVm)
        {
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    UserId = user.Id,
                    Content = reviewVm.Content,
                    DatePosted = DateTime.Now
                };

                _session.AddReview(review);

                return RedirectToAction("Index");
            }

            var reviews = _session.GetAllReviews();
            var viewModel = new Tuple<IEnumerable<Review>, ReviewViewModel>(reviews, reviewVm);
            return View("Index", viewModel);
        }
    }
}
