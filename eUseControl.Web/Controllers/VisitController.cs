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
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var viewModel = new VisitPageViewModel
            {
                NewVisit = new VisitRequest(),
                Visits = _session.GetAllVisits().Where(v => v.UserId == user.Id).ToList()
            };
            ViewBag.Properties = _session.GetAllProperties();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schedule(VisitPageViewModel viewModel)
        {
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                viewModel.NewVisit.UserId = user.Id;
                _session.AddVisitRequest(viewModel.NewVisit);
                return RedirectToAction("Schedule");
            }

            viewModel.Visits = _session.GetAllVisits().Where(v => v.UserId == user.Id).ToList();
            ViewBag.Properties = _session.GetAllProperties();
            return View(viewModel);
        }
    }
}
