using System.Collections.Generic;
using eUseControl.Domain.Entities.Villa;

namespace eUseControl.Web.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<VillaDbTable> Villas { get; set; }
    }
}
