using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ReviewsContext : DbContext
    {
        public ReviewsContext() : base("name=eUseControlVillaAgency2")
        {
        }

        public virtual DbSet<Review> Reviews { get; set; }
    }
}

