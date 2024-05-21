using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : 
            base("eUseControlVillaAgency2")
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
