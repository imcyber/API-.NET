﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.data.Context;

namespace data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211102172302_UserMigration")]
    partial class UserMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52240ef3-b83f-48cd-af4a-f3d88fc1759d"),
                            CreateAt = new DateTime(2021, 11, 2, 14, 23, 2, 7, DateTimeKind.Local).AddTicks(5004),
                            UpdateAt = new DateTime(2021, 11, 2, 14, 23, 2, 8, DateTimeKind.Local).AddTicks(5353),
                            email = "adm@mail",
                            name = "Administrador"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}