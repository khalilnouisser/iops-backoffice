using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class initdb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Countries_CountryID",
                table: "Inscriptions");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    EmailAddress = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Text = table.Column<string>(maxLength: 9000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                });

            migrationBuilder.AlterColumn<string>(
                name: "University",
                table: "Inscriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lname",
                table: "Inscriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fname",
                table: "Inscriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAdress",
                table: "Inscriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryID",
                table: "Inscriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Countries_CountryID",
                table: "Inscriptions",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Countries_CountryID",
                table: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "University",
                table: "Inscriptions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Lname",
                table: "Inscriptions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Fname",
                table: "Inscriptions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EmailAdress",
                table: "Inscriptions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CountryID",
                table: "Inscriptions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Countries_CountryID",
                table: "Inscriptions",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
