namespace EvitelLib.Migrations
{
    using EvitelLib.Common;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBCreate : DbZPTMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginAccesses",
                c => new
                    {
                        LoginAccessId = c.Int(nullable: false, identity: true),
                        AccessName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.LoginAccessId);
            
            CreateTable(
                "dbo.LoginAccessUsers",
                c => new
                    {
                        LoginAccessUserId = c.Int(nullable: false, identity: true),
                        LoginUserId = c.Int(nullable: false),
                        LoginAccessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoginAccessUserId)
                .ForeignKey("dbo.LoginUsers", t => t.LoginUserId, cascadeDelete: true)
                .Index(t => t.LoginUserId);
            
            CreateTable(
                "dbo.LoginUsers",
                c => new
                    {
                        LoginUserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        LoginName = c.String(maxLength: 50),
                        LoginPassword = c.String(maxLength: 50),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LoginUserId);
            
            CreateTable(
                "dbo.MainEventLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dtCreate = c.DateTime(nullable: false),
                        LoginUserId = c.Int(nullable: false),
                        eventType = c.Int(nullable: false),
                        eventSubType = c.Int(nullable: false),
                        Program = c.String(maxLength: 50),
                        Text = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        sValue = c.String(),
                        iValue = c.Int(),
                        dValue = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            SqlResourceExecute("EvitelLib.Migrations.Seed.001.Initial.sql");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginAccessUsers", "LoginUserId", "dbo.LoginUsers");
            DropIndex("dbo.LoginAccessUsers", new[] { "LoginUserId" });
            DropTable("dbo.MainSettings");
            DropTable("dbo.MainEventLogs");
            DropTable("dbo.LoginUsers");
            DropTable("dbo.LoginAccessUsers");
            DropTable("dbo.LoginAccesses");
        }
    }
}
