namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using eUseControl.Domain.Entities.User;
    using eUseControl.Domain.Enums;
    using eUseControl.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<eUseControl.BusinessLogic.DBModel.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eUseControl.BusinessLogic.DBModel.UserContext context)
        {
            var adminUser = context.Users.FirstOrDefault(u => u.Username == "admin");

            if (adminUser == null)
            {
                context.Users.AddOrUpdate(new UDbTable
                {
                    Username = "admin",
                    Email = "admin@example.com",
                    Password = LoginHelper.HashGen("admin123"),
                    RegistrationDateTime = DateTime.Now,
                    RegistrationIp = "127.0.0.1",
                    Level = URole.Admin
                });
            }
            else
            {
                adminUser.Level = URole.Admin;
                context.Entry(adminUser).State = EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}
