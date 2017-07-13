using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOPSApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contexts",
                columns: table => new
                {
                    NomContext = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contexts", x => x.NomContext);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Continent = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SiteURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EmailAdress = table.Column<string>(nullable: false),
                    Fname = table.Column<string>(nullable: false),
                    Lname = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ProfilePic = table.Column<string>(nullable: true),
                    AdminPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    InscID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CEPic = table.Column<string>(nullable: true),
                    CinPic = table.Column<string>(nullable: true),
                    ContextID = table.Column<string>(nullable: true),
                    CountryID = table.Column<string>(nullable: true),
                    DateInsc = table.Column<DateTime>(nullable: false),
                    EmailAdress = table.Column<string>(nullable: true),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    University = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.InscID);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Contexts_ContextID",
                        column: x => x.ContextID,
                        principalTable: "Contexts",
                        principalColumn: "NomContext",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ContextID",
                table: "Inscriptions",
                column: "ContextID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_CountryID",
                table: "Inscriptions",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Contexts");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
