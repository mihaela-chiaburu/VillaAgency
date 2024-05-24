using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System.IO;
using eUseControl.BusinessLogic;

namespace eUseControl.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ISession _session;

        public ProfileController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = Session["User"] as UserMinimal;
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var profile = _session.GetUserProfile(user.Id);
            if (profile == null)
            {
                profile = new UserProfile
                {
                    UserId = user.Id,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    ProfileImage = string.Empty,
                    Age = 0,
                    Biography = string.Empty
                };
                _session.UpdateUserProfile(profile);
            }
            ViewBag.Username = user.Username;
            return View(profile);
        }


        [HttpPost]
        public ActionResult UpdateProfile(UserProfile profile, HttpPostedFileBase ProfileImage)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as UserMinimal;
                profile.UserId = user.Id;

                if (ProfileImage != null && ProfileImage.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ProfileImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    ProfileImage.SaveAs(path);
                    profile.ProfileImage = "~/Uploads/" + fileName;
                }

                _session.UpdateUserProfile(profile);

                return RedirectToAction("Index");
            }

            return View("Index", profile);
        }
    }
}
