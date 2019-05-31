﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieBomb.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovieBomb.Migrations
{
    [DbContext(typeof(MovieBombContext))]
    partial class MovieBombContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MovieBomb.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("MovieBomb.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bomb");

                    b.Property<int>("GameID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MovieBomb.Models.Round", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameID");

                    b.Property<int>("PlayerID");

                    b.Property<int>("RoundState");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("MovieBomb.Models.Turn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PlayerID");

                    b.Property<int>("RoundID");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("RoundID");

                    b.ToTable("Turn");
                });

            modelBuilder.Entity("MovieBomb.Models.Player", b =>
                {
                    b.HasOne("MovieBomb.Models.Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieBomb.Models.Round", b =>
                {
                    b.HasOne("MovieBomb.Models.Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieBomb.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieBomb.Models.Turn", b =>
                {
                    b.HasOne("MovieBomb.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID");

                    b.HasOne("MovieBomb.Models.Round")
                        .WithMany("Turns")
                        .HasForeignKey("RoundID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}