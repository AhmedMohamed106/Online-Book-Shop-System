﻿// <auto-generated />
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240323133338_AddItemsToCategoryTable")]
    partial class AddItemsToCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 5,
                            Name = "Ali"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 4,
                            Name = "Mohamed"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 6,
                            Name = "Ahmed"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 8,
                            Name = "Ahmed"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
