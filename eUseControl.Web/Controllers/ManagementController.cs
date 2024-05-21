using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Villa;
using eUseControl.Web.Filters;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
     [AdminAuthorize]
    public class ManagementController : Controller
    {
        private readonly IAdminSession _adminSession;

        public ManagementController()
        {
            var bl = new BussinesLogic();
            _adminSession = bl.GetAdminSessionBL();
        }

        // GET: Management
        public ActionResult Index()
        {
            var villas = _adminSession.GetAllVillas();
            return View(villas);
        }

        // GET: Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Management/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VillaDbTable villa)
        {
            if (ModelState.IsValid)
            {
                _adminSession.AddVilla(villa);
                return RedirectToAction("Index");
            }

            return View(villa);
        }

        // GET: Management/Edit/5
        public ActionResult Edit(int id)
        {
            var villaEntity = _adminSession.GetVillaById(id);
            if (villaEntity == null)
            {
                return HttpNotFound();
            }

            var villaViewModel = new Villa
            {
                Id = villaEntity.Id,
                Name = villaEntity.Name,
                Description = villaEntity.Description,
                Location = villaEntity.Location,
                Price = villaEntity.Price,
                Bedrooms = villaEntity.Bedrooms,
                Bathrooms = villaEntity.Bathrooms,
                Area = villaEntity.Area,
                Parking = villaEntity.Parking,
                ImageUrl = villaEntity.ImageUrl
            };

            return View(villaViewModel);
        }

        // POST: Management/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Villa villaViewModel)
        {
            if (ModelState.IsValid)
            {
                var villaEntity = new VillaDbTable
                {
                    Id = villaViewModel.Id,
                    Name = villaViewModel.Name,
                    Description = villaViewModel.Description,
                    Location = villaViewModel.Location,
                    Price = villaViewModel.Price,
                    Bedrooms = villaViewModel.Bedrooms,
                    Bathrooms = villaViewModel.Bathrooms,
                    Area = villaViewModel.Area,
                    Parking = villaViewModel.Parking,
                    ImageUrl = villaViewModel.ImageUrl
                };

                _adminSession.UpdateVilla(villaEntity);
                return RedirectToAction("Index");
            }
            return View(villaViewModel);
        }

        // GET: Management/Delete/5
        public ActionResult Delete(int id)
        {
            var villaEntity = _adminSession.GetVillaById(id);
            if (villaEntity == null)
            {
                return HttpNotFound();
            }

            var villaViewModel = new Villa
            {
                Id = villaEntity.Id,
                Name = villaEntity.Name,
                Description = villaEntity.Description,
                Location = villaEntity.Location,
                Price = villaEntity.Price,
                Bedrooms = villaEntity.Bedrooms,
                Bathrooms = villaEntity.Bathrooms,
                Area = villaEntity.Area,
                Parking = villaEntity.Parking,
                ImageUrl = villaEntity.ImageUrl
            };

            return View(villaViewModel);
        }

        // POST: Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _adminSession.DeleteVilla(id);
            return RedirectToAction("Index");
        }
    }
}
