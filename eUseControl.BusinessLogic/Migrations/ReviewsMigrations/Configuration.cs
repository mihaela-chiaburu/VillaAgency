namespace eUseControl.BusinessLogic.Migrations.ReviewsMigrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<eUseControl.BusinessLogic.DBModel.ReviewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ReviewsMigrations";
        }

        protected override void Seed(eUseControl.BusinessLogic.DBModel.ReviewsContext context)
        {
            // Seed data if necessary
        }
    }
}
