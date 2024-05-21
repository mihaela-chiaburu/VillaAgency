using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Villa;
using eUseControl.Web.Extension;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAdminSession _adminSession;

        public HomeController()
        {
            var bl = new BussinesLogic();
            _adminSession = bl.GetAdminSessionBL();
        }

        // GET: Home
        public ActionResult Index()
        {
            var villas = _adminSession.GetAllVillas().ToList();

            var model = new VillaViewModel
            {
                Villas = villas
            };

            return View(model);
        }


        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Properties()
        {
            var villas = _adminSession.GetAllVillas().ToList();

            var model = new VillaViewModel
            {
                Villas = villas
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var villa = _adminSession.GetVillaById(id);
            if (villa == null)
            {
                return HttpNotFound();
            }

            var model = new VillaViewModel
            {
                Villas = new List<VillaDbTable> { villa }
            };

            return View(model);
        }


        public ActionResult Reviews()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}