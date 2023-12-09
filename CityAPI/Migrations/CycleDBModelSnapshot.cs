﻿// <auto-generated />
using System;
using CityAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityAPI.Migrations
{
    [DbContext(typeof(CycleDB))]
    partial class CycleDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CityAPI.Class.CityRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CycleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("approximateTravelTime")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CycleId");

                    b.ToTable("CityRoute");
                });

            modelBuilder.Entity("CityAPI.Class.XYCoordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityRouteId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityRouteId");

                    b.ToTable("XYCoordinate");
                });

            modelBuilder.Entity("CityAPI.Model.Cycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoutesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cycles");
                });

            modelBuilder.Entity("CityAPI.Model.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("CityAPI.Class.CityRoute", b =>
                {
                    b.HasOne("CityAPI.Model.Cycle", null)
                        .WithMany("Routes")
                        .HasForeignKey("CycleId");
                });

            modelBuilder.Entity("CityAPI.Class.XYCoordinate", b =>
                {
                    b.HasOne("CityAPI.Class.CityRoute", null)
                        .WithMany("movementArray")
                        .HasForeignKey("CityRouteId");
                });

            modelBuilder.Entity("CityAPI.Model.Node", b =>
                {
                    b.HasOne("CityAPI.Model.Node", null)
                        .WithMany("RelatedNodes")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("CityAPI.Class.CityRoute", b =>
                {
                    b.Navigation("movementArray");
                });

            modelBuilder.Entity("CityAPI.Model.Cycle", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("CityAPI.Model.Node", b =>
                {
                    b.Navigation("RelatedNodes");
                });
#pragma warning restore 612, 618
        }
    }
}
