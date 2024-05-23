using System.Collections.Generic;
using eUseControl.Domain.Entities.Villa;

namespace eUseControl.Web.Models
{
    public class VillaViewModel
    {
        public IEnumerable<VillaDbTable> Villas { get; set; } = new List<VillaDbTable>();
    }
}