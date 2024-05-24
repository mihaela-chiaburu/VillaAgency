namespace eUseControl.BusinessLogic.Migrations.VisitsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        VisitDate = c.DateTime(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitRequests");
        }
    }
}
