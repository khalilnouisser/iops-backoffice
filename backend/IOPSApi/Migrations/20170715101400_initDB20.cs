using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class initDB20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthdayDate",
                table: "Inscriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Inscriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthdayDate",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Inscriptions");
        }
    }
}
