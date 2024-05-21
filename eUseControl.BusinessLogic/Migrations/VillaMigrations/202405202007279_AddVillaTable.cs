namespace eUseControl.BusinessLogic.Migrations.VillaMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVillaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VillaDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bedrooms = c.Int(nullable: false),
                        Bathrooms = c.Int(nullable: false),
                        Area = c.Double(nullable: false),
                        Parking = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VillaDbTables");
        }
    }
}
