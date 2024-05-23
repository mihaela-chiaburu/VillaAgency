using eUseControl.Domain.Entities.User;
using System.Collections.Generic;

namespace eUseControl.Web.Models
{
    public class ReviewPageViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public Review NewReview { get; set; }
    }
}
