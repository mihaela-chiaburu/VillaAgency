using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<URegisterData>(register);

                data.RegistrationIp = Request.UserHostAddress;
                data.RegistrationDateTime = DateTime.Now;

                var userRegister = _session.UserRegister(data);
                if (userRegister.Status)
                {
                    // Store username in session
                    Session["Username"] = register.Username;

                    // Generate a cookie if needed
                    HttpCookie cookie = _session.GenCookie(register.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                }
            }

            return View(register);
        }
    }
}
