using System;
using EvitelLib2.Common;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvitelLib2.Migrations
{
    public partial class firstMigration : DbZPTMigration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginAccesses",
                columns: table => new
                {
                    LoginAccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAccesses", x => x.LoginAccessId);
                });

            migrationBuilder.CreateTable(
                name: "LoginUsers",
                columns: table => new
                {
                    LoginUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoginPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsers", x => x.LoginUserId);
                });

            migrationBuilder.CreateTable(
                name: "MainEventLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoginUserId = table.Column<int>(type: "int", nullable: false),
                    eventCode = table.Column<int>(type: "int", nullable: false),
                    eventSubCode = table.Column<int>(type: "int", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainSettings",
                columns: table => new
                {
                    MainSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iValue = table.Column<int>(type: "int", nullable: true),
                    dValue = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSettings", x => x.MainSettingId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateType = table.Column<int>(type: "int", nullable: false),
                    StateValue = table.Column<int>(type: "int", nullable: false),
                    DescriptionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescriptionValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "LoginAccessUsers",
                columns: table => new
                {
                    LoginAccessUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUserId = table.Column<int>(type: "int", nullable: false),
                    LoginAccessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAccessUsers", x => x.LoginAccessUserId);
                    table.ForeignKey(
                        name: "FK_LoginAccessUsers_LoginUsers_LoginUserId",
                        column: x => x.LoginUserId,
                        principalTable: "LoginUsers",
                        principalColumn: "LoginUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginAccessUsers_LoginUserId",
                table: "LoginAccessUsers",
                column: "LoginUserId");

            migrationBuilder.Sql(GetSqlResource("EvitelLib2.Migrations.Seed.001.Initial.sql"));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginAccesses");

            migrationBuilder.DropTable(
                name: "LoginAccessUsers");

            migrationBuilder.DropTable(
                name: "MainEventLogs");

            migrationBuilder.DropTable(
                name: "MainSettings");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "LoginUsers");
        }
    }
}
