using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nagarro.ReimbursementPortal.webAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReimTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    lastUpdatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    PanNumber = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    BankAccountNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RetypePassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignupUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ReimType = table.Column<string>(nullable: true),
                    RequestedAmount = table.Column<int>(nullable: false),
                    ApprovedAmount = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    RecipeLink = table.Column<string>(nullable: true),
                    Flag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReimTypes");

            migrationBuilder.DropTable(
                name: "SignupUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
