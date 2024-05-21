using System.Collections.Generic;
using eUseControl.Domain.Entities.Villa;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IAdminSession
    {
        List<VillaDbTable> GetAllVillas();
        VillaDbTable GetVillaById(int id);
        void AddVilla(VillaDbTable villa);
        void UpdateVilla(VillaDbTable villa);
        void DeleteVilla(int id);
    }
}
