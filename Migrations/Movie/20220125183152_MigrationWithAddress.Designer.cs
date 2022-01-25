﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAPI.Data;
using ProjectAPI.Models;

namespace ProjectAPI.Migrations.Movie
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220125183152_MigrationWithAddress")]
    partial class MigrationWithAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.Property<int>("Moviesid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Usersid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Moviesid", "Usersid");

                    b.HasIndex("Usersid");

                    b.ToTable("MovieUser");
                });

            modelBuilder.Entity("ProjectAPI.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("apartment")
                        .HasColumnType("TEXT");

                    b.Property<string>("city")
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .HasColumnType("TEXT");

                    b.Property<string>("county")
                        .HasColumnType("TEXT");

                    b.Property<int>("number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("postal_code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("street")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ProjectAPI.Models.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("release_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ProjectAPI.Models.Participant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Movieid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("date_of_birth")
                        .HasColumnType("TEXT");

                    b.Property<int?>("fan_mail_addressid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("surname")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Movieid");

                    b.HasIndex("fan_mail_addressid");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("ProjectAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.HasOne("ProjectAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("Moviesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Usersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectAPI.Models.Participant", b =>
                {
                    b.HasOne("ProjectAPI.Models.Movie", null)
                        .WithMany("Participants")
                        .HasForeignKey("Movieid");

                    b.HasOne("ProjectAPI.Models.Address", "fan_mail_address")
                        .WithMany()
                        .HasForeignKey("fan_mail_addressid");

                    b.Navigation("fan_mail_address");
                });

            modelBuilder.Entity("ProjectAPI.Models.Movie", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
