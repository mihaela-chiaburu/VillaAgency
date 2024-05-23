using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using eUseControl.Domain.Entities.Villa;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.DBModel
{
    public class VisitContext : DbContext
    {
        public VisitContext() : base("name=eUseControlVillaAgency2")
        {
        }

        public DbSet<VisitRequest> VisitRequests { get; set; }
    }
}
