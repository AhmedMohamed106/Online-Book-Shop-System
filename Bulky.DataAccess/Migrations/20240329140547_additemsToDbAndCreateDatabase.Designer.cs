﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240329140547_additemsToDbAndCreateDatabase")]
    partial class additemsToDbAndCreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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

            modelBuilder.Entity("Bulky.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "George forbs",
                            CategoryId = 1,
                            Description = "A book speaks about essential design patterns",
                            ISBN = "SWD9999901",
                            ImgUrl = "",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Design patterns head first"
                        },
                        new
                        {
                            Id = 2,
                            Author = "George forbs",
                            CategoryId = 2,
                            Description = "A book speaks about essential design patterns",
                            ISBN = "SWD9999901",
                            ImgUrl = "",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Design patterns head first"
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Func",
                            CategoryId = 1,
                            Description = "A book speaks about essential design patterns",
                            ISBN = "SWD980111",
                            ImgUrl = "",
                            ListPrice = 98.0,
                            Price = 85.0,
                            Price100 = 70.0,
                            Price50 = 80.0,
                            Title = "GOF"
                        },
                        new
                        {
                            Id = 4,
                            Author = "George forbs",
                            CategoryId = 3,
                            Description = "A book speaks about essential design patterns",
                            ISBN = "SWD9999901",
                            ImgUrl = "",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Design patterns head first"
                        },
                        new
                        {
                            Id = 5,
                            Author = "George forbs",
                            CategoryId = 4,
                            Description = "A book speaks about essential design patterns",
                            ISBN = "SWD9999901",
                            ImgUrl = "",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Design patterns head first"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Models.Product", b =>
                {
                    b.HasOne("Bulky.Models.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}