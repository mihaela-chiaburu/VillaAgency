﻿namespace eUseControl.BusinessLogic.Migrations.SessionMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        CookieString = c.String(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sessions");
        }
    }
}
