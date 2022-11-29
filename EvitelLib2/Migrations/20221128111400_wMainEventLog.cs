using EvitelLib2.Common;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvitelLib2.Migrations
{
    public partial class wMainEventLog : DbZPTMigration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetSqlResource("EvitelLib2.Migrations.Seed.002.wMainEventLog.sql"));
            migrationBuilder.Sql(GetSqlResource("EvitelLib2.Migrations.Seed.002.wMainEventLog2.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.wMainEventlog");
        }
    }
}
