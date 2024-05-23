using System;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class VisitController : Controller
    {
        private readonly ISession _session;

        public VisitController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        public ActionResult Schedule()
        {
            ViewBag.Properties = _session.GetAllProperties();
            return View(new VisitRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schedule(VisitRequest request)
        {
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                request.UserId = user.Id;
                _session.AddVisitRequest(request);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Properties = _session.GetAllProperties();
            return View(request);
        }
    }
}
