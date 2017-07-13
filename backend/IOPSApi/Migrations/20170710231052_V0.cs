using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Continent",
                table: "Countries",
                newName: "ContinentID");

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    ContinentID = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.ContinentID);
                });

            migrationBuilder.AlterColumn<string>(
                name: "ContinentID",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentID",
                table: "Countries",
                column: "ContinentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Continent_ContinentID",
                table: "Countries",
                column: "ContinentID",
                principalTable: "Continent",
                principalColumn: "ContinentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Continent_ContinentID",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "ContinentID",
                table: "Countries",
                newName: "Continent");

            migrationBuilder.DropIndex(
                name: "IX_Countries_ContinentID",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "Continent");

            migrationBuilder.AlterColumn<string>(
                name: "Continent",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
