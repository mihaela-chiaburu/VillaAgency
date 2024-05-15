using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Extension;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            /*SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }*/

            var user = System.Web.HttpContext.Current.GetMySessionObject();
            UserData u = new UserData
            {
                Username = "Customer",
                Products = new List<string> {"Product #1", "Product #2", "Product #3", "Product #4"}
            };

            return View(u);
        }

        public ActionResult Product()
        {
            var product = Request.QueryString["p"];

            UserData u = new UserData();
            u.Username = "Customer";
            u.SingleProduct = product;

            return View(u);
        }

        [HttpPost]
        public ActionResult Product(string btn)
        {
            return RedirectToAction("Product", "Home", new { @p = btn });
        }
    }
}