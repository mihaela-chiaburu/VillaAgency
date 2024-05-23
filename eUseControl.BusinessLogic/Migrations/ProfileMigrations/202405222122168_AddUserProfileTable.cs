namespace eUseControl.BusinessLogic.Migrations.ProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ProfileImage = c.String(),
                        Age = c.Int(nullable: false),
                        Biography = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
        }
    }
}
