namespace EvitelLib.Migrations
{
    using EvitelLib.Common;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class state : DbZPTMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateType = c.Int(nullable: false),
                        StateValue = c.Int(nullable: false),
                        DescriptionType = c.String(maxLength: 50),
                        DescriptionValue = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StateId);            
            SqlResourceExecute("EvitelLib.Migrations.Seed.002.State.sql");
        }

        public override void Down()
        {
            DropTable("dbo.States");
        }
    }
}
