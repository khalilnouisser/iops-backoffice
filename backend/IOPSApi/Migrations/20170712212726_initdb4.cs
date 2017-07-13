using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class initdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsableName",
                table: "Countries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "News",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ResponsableName",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);
        }
    }
}
