using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IOPSApi.Data;
using IOPSApi.Models;

namespace IOPSApi.Migrations
{
    [DbContext(typeof(MysqlDBContext))]
    [Migration("20170714072936_InitShit")]
    partial class InitShit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("IOPSApi.Models.Context", b =>
                {
                    b.Property<string>("NomContext")
                        .ValueGeneratedOnAdd();

                    b.HasKey("NomContext");

                    b.ToTable("Contexts");
                });

            modelBuilder.Entity("IOPSApi.Models.Continent", b =>
                {
                    b.Property<string>("ContinentID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ContinentID");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("IOPSApi.Models.Country", b =>
                {
                    b.Property<string>("CountryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContinentID")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ResponsableName");

                    b.Property<string>("SiteURL")
                        .IsRequired();

                    b.HasKey("CountryID");

                    b.HasIndex("ContinentID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("IOPSApi.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryID");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Descriptions")
                        .IsRequired();

                    b.Property<string>("ImageURL");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("IOPSApi.Models.Inscription", b =>
                {
                    b.Property<int>("InscID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEPic");

                    b.Property<string>("CinPic");

                    b.Property<string>("ContextID");

                    b.Property<string>("CountryID")
                        .IsRequired();

                    b.Property<DateTime?>("DateInsc");

                    b.Property<string>("EmailAdress")
                        .IsRequired();

                    b.Property<string>("Fname")
                        .IsRequired();

                    b.Property<string>("Lname")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("University")
                        .IsRequired();

                    b.HasKey("InscID");

                    b.HasIndex("ContextID");

                    b.HasIndex("CountryID");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("IOPSApi.Models.Messages", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryID");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(9000);

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("IOPSApi.Models.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DatePub");

                    b.Property<string>("PhotoURL");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.HasKey("NewsID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("IOPSApi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreation");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("EmailAdress")
                        .IsRequired();

                    b.Property<string>("Fname")
                        .IsRequired();

                    b.Property<string>("Lname")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("ProfilePic");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("IOPSApi.Models.Admin", b =>
                {
                    b.HasBaseType("IOPSApi.Models.User");

                    b.Property<string>("AdminPassword")
                        .IsRequired();

                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("IOPSApi.Models.Country", b =>
                {
                    b.HasOne("IOPSApi.Models.Continent", "Continent")
                        .WithMany("countries")
                        .HasForeignKey("ContinentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IOPSApi.Models.Inscription", b =>
                {
                    b.HasOne("IOPSApi.Models.Context", "Context")
                        .WithMany("Inscriptions")
                        .HasForeignKey("ContextID");

                    b.HasOne("IOPSApi.Models.Country", "Country")
                        .WithMany("Inscriptions")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
