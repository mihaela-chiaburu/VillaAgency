namespace eUseControl.BusinessLogic.Migrations.VillaMigrations
{
    using eUseControl.BusinessLogic.DBModel;
    using eUseControl.Domain.Entities.Villa;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eUseControl.BusinessLogic.DBModel.VillaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\VillaMigrations";
        }

        protected override void Seed(VillaContext context)
        {
            context.Villas.AddOrUpdate(
                v => v.Name,
                new VillaDbTable
                {
                    Name = "Luxury Villa",
                    Description = "18 Old Street Miami, OR 97219",
                    Location = "Miami, OR",
                    Price = 2264000,
                    Bedrooms = 8,
                    Bathrooms = 8,
                    Area = 545,
                    Parking = 6,
                    ImageUrl = "~/assets/images/property-01.jpg"
                },
                new VillaDbTable
                {
                    Name = "Luxury Villa",
                    Description = "54 New Street Florida, OR 27001",
                    Location = "Florida, OR",
                    Price = 1180000,
                    Bedrooms = 6,
                    Bathrooms = 5,
                    Area = 450,
                    Parking = 8,
                    ImageUrl = "~/assets/images/property-02.jpg"
                },
                new VillaDbTable
                {
                    Name = "Luxury Villa",
                    Description = "26 Mid Street Portland, OR 38540",
                    Location = "Portland, OR",
                    Price = 1460000,
                    Bedrooms = 5,
                    Bathrooms = 4,
                    Area = 225,
                    Parking = 10,
                    ImageUrl = "~/assets/images/property-03.jpg"
                },
                new VillaDbTable
                {
                    Name = "Apartment",
                    Description = "12 Hope Street Portland, OR 12650",
                    Location = "Portland, OR",
                    Price = 584500,
                    Bedrooms = 4,
                    Bathrooms = 3,
                    Area = 125,
                    Parking = 2,
                    ImageUrl = "~/assets/images/property-04.jpg"
                },
                new VillaDbTable
                {
                    Name = "Penthouse",
                    Description = "34 Hope Street Portland, OR 42680",
                    Location = "Portland, OR",
                    Price = 925600,
                    Bedrooms = 4,
                    Bathrooms = 4,
                    Area = 180,
                    Parking = 2,
                    ImageUrl = "~/assets/images/property-05.jpg"
                },
                new VillaDbTable
                {
                    Name = "Modern Condo",
                    Description = "22 Hope Street Portland, OR 16540",
                    Location = "Portland, OR",
                    Price = 450000,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    Area = 165,
                    Parking = 3,
                    ImageUrl = "~/assets/images/property-06.jpg"
                },
                new VillaDbTable
                {
                    Name = "Luxury Villa",
                    Description = "14 Mid Street Miami, OR 36450",
                    Location = "Miami, OR",
                    Price = 980000,
                    Bedrooms = 8,
                    Bathrooms = 8,
                    Area = 550,
                    Parking = 12,
                    ImageUrl = "~/assets/images/property-03.jpg"
                },
                new VillaDbTable
                {
                    Name = "Luxury Villa",
                    Description = "26 Old Street Miami, OR 12870",
                    Location = "Miami, OR",
                    Price = 1520000,
                    Bedrooms = 12,
                    Bathrooms = 15,
                    Area = 380,
                    Parking = 14,
                    ImageUrl = "~/assets/images/property-02.jpg"
                },
                new VillaDbTable
                {
                    Name = "Luxury Villa",
                    Description = "34 New Street Miami, OR 24650",
                    Location = "Miami, OR",
                    Price = 3145000,
                    Bedrooms = 10,
                    Bathrooms = 12,
                    Area = 860,
                    Parking = 10,
                    ImageUrl = "~/assets/images/property-01.jpg"
                }
            );

            context.SaveChanges();
        }

    }
}
