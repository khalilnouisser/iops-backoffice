using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class initDB19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Countries_CountryID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CountryID",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "CountryID",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryID",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CountryID",
                table: "Messages",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Countries_CountryID",
                table: "Messages",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
