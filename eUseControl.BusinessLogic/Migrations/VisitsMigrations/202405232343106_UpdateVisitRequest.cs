namespace eUseControl.BusinessLogic.Migrations.VisitsMigrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateVisitRequest : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.VisitRequests", "PropertyId");
            AddForeignKey("dbo.VisitRequests", "PropertyId", "dbo.VillaDbTables", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.VisitRequests", "PropertyId", "dbo.VillaDbTables");
            DropIndex("dbo.VisitRequests", new[] { "PropertyId" });
        }
    }
}
