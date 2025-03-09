using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SenderCity = table.Column<string>(type: "TEXT", nullable: true),
                    SenderAdress = table.Column<string>(type: "TEXT", nullable: true),
                    RecieverCity = table.Column<string>(type: "TEXT", nullable: true),
                    RecieverAdress = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<uint>(type: "INTEGER", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
