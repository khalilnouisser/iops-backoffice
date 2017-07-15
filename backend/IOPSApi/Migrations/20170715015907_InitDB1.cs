using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class InitDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "News",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Countries_CountryID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CountryID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "CountryID",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
