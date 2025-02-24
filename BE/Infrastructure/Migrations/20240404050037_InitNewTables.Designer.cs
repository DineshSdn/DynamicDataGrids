﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20240404050037_InitNewTables")]
    partial class InitNewTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Authentication.User1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTable");
                });

            modelBuilder.Entity("Domain.Entities.DgCore", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("code_key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("modified_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modified_datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("show_health_profile")
                        .HasColumnType("bit");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("type");

                    b.ToTable("dg_core");
                });

            modelBuilder.Entity("Domain.Entities.DgToRoles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("datagrid_id")
                        .HasColumnType("int");

                    b.Property<int?>("modified_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modified_datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("datagrid_id");

                    b.HasIndex("role_id");

                    b.ToTable("dg_to_core");
                });

            modelBuilder.Entity("Domain.Entities.MasterDgTypes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_datetime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("modified_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modified_datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("master_Dg_Types");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("role_nmae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Domain.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarTable");
                });

            modelBuilder.Entity("Domain.Entity.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegisterTable");
                });

            modelBuilder.Entity("Domain.Entities.DgCore", b =>
                {
                    b.HasOne("Domain.Entities.MasterDgTypes", "MasterDgTypes")
                        .WithMany()
                        .HasForeignKey("type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterDgTypes");
                });

            modelBuilder.Entity("Domain.Entities.DgToRoles", b =>
                {
                    b.HasOne("Domain.Entities.DgCore", "DgCore")
                        .WithMany()
                        .HasForeignKey("datagrid_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Role", "role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DgCore");

                    b.Navigation("role");
                });
#pragma warning restore 612, 618
        }
    }
}
