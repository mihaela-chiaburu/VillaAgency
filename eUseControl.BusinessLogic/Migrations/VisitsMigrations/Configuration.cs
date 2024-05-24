using System.Data.Entity.Migrations;
using eUseControl.BusinessLogic.DBModel;

namespace eUseControl.BusinessLogic.Migrations.VisitsMigrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VisitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\VisitsMigrations";
        }

        protected override void Seed(VisitContext context)
        {
            // Seed initial data if necessary
        }
    }
}
