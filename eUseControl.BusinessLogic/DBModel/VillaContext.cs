using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using eUseControl.Domain.Entities.Villa;

namespace eUseControl.BusinessLogic.DBModel
{
    public class VillaContext : DbContext
    {
        public VillaContext() : base("name=eUseControlVillaAgency2")
        {
        }

        public DbSet<VillaDbTable> Villas { get; set; }
    }
}
