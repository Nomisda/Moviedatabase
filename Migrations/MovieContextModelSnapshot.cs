﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDatabase.Data;

#nullable disable

namespace MovieDatabase.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("MovieDatabase.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RegieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieDatabase.Models.MovieSchauspieler", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchauspielerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "SchauspielerId");

                    b.HasIndex("SchauspielerId");

                    b.ToTable("MovieSchauspieler");
                });

            modelBuilder.Entity("MovieDatabase.Models.Regisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Regisseure");
                });

            modelBuilder.Entity("MovieDatabase.Models.Schauspieler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Schauspieler");
                });

            modelBuilder.Entity("MovieDatabase.Models.Movie", b =>
                {
                    b.HasOne("MovieDatabase.Models.Regisseur", "Regie")
                        .WithMany("Movies")
                        .HasForeignKey("RegieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Regie");
                });

            modelBuilder.Entity("MovieDatabase.Models.MovieSchauspieler", b =>
                {
                    b.HasOne("MovieDatabase.Models.Movie", "Movie")
                        .WithMany("MovieSchauspieler")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDatabase.Models.Schauspieler", "Schauspieler")
                        .WithMany("MovieSchauspieler")
                        .HasForeignKey("SchauspielerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Schauspieler");
                });

            modelBuilder.Entity("MovieDatabase.Models.Movie", b =>
                {
                    b.Navigation("MovieSchauspieler");
                });

            modelBuilder.Entity("MovieDatabase.Models.Regisseur", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieDatabase.Models.Schauspieler", b =>
                {
                    b.Navigation("MovieSchauspieler");
                });
#pragma warning restore 612, 618
        }
    }
}
