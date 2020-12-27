﻿// <auto-generated />
using System;
using FKTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FKTest.Migrations
{
    [DbContext(typeof(FkDbContext))]
    partial class FkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FKTest.Models.Child", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(95) CHARACTER SET utf8mb4");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ParentCode")
                        .IsRequired()
                        .HasColumnType("varchar(95) CHARACTER SET utf8mb4");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("char(36)");

                    b.HasKey("Code");

                    b.HasIndex("ParentCode");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("FKTest.Models.Parent", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(95) CHARACTER SET utf8mb4");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Code");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("FKTest.Models.Child", b =>
                {
                    b.HasOne("FKTest.Models.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("FKTest.Models.Parent", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
