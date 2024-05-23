namespace eUseControl.BusinessLogic.Migrations.ReviewsMigrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddReviewsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    Content = c.String(nullable: false, maxLength: 500),
                    DatePosted = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.UserProfiles");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropTable("dbo.Reviews");
        }
    }
}
