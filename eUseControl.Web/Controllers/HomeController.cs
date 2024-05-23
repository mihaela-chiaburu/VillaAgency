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
        public ActionResult Search(string name, decimal? minPrice, decimal? maxPrice)
        {
            var villas = _adminSession.GetAllVillas().AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                villas = villas.Where(v => v.Name.Contains(name));
            }

            if (minPrice.HasValue)
            {
                villas = villas.Where(v => v.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                villas = villas.Where(v => v.Price <= maxPrice.Value);
            }

            var model = new SearchViewModel
            {
                Name = name,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Villas = villas.ToList()
            };

            return View(model);
        }
    }
}