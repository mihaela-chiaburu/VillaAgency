using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using eUseControl.Domain.Entities.Villa;
using eUseControl.BusinessLogic.DBModel;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi
    {
        public List<VillaDbTable> GetAllVillas()
        {
            using (var db = new VillaContext())
            {
                return db.Villas.ToList();
            }
        }

        public VillaDbTable GetVillaById(int id)
        {
            using (var db = new VillaContext())
            {
                return db.Villas.Find(id);
            }
        }

        public void AddVilla(VillaDbTable villa)
        {
            using (var db = new VillaContext())
            {
                db.Villas.Add(villa);
                db.SaveChanges();
            }
        }

        public void UpdateVilla(VillaDbTable villa)
        {
            using (var db = new VillaContext())
            {
                db.Entry(villa).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteVilla(int id)
        {
            using (var db = new VillaContext())
            {
                var villa = db.Villas.Find(id);
                if (villa != null)
                {
                    db.Villas.Remove(villa);
                    db.SaveChanges();
                }
            }
        }
    }
}
