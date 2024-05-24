﻿using System.Collections.Generic;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Villa;

namespace eUseControl.BusinessLogic
{
    public class AdminSessionBL : AdminApi, IAdminSession
    {
        private readonly AdminApi _villaApi = new AdminApi();

        public List<VillaDbTable> GetAllVillas()
        {
            return _villaApi.GetAllVillas();
        }

        public VillaDbTable GetVillaById(int id)
        {
            return _villaApi.GetVillaById(id);
        }

        public void AddVilla(VillaDbTable villa)
        {
            _villaApi.AddVilla(villa);
        }

        public void UpdateVilla(VillaDbTable villa)
        {
            _villaApi.UpdateVilla(villa);
        }

        public void DeleteVilla(int id)
        {
            _villaApi.DeleteVilla(id);
        }
    }
}
