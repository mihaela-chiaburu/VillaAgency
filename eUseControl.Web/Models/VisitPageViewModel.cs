using System.Collections.Generic;
using eUseControl.Domain.Entities;

namespace eUseControl.Web.Models
{
    public class VisitPageViewModel
    {
        public VisitRequest NewVisit { get; set; }
        public IEnumerable<VisitRequest> Visits { get; set; }
    }
}
