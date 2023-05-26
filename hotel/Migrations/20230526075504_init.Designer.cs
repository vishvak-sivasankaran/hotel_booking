﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hotel.models;

#nullable disable

namespace hotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20230526075504_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hotel.models.HotelCustomers", b =>
                {
                    b.Property<int>("Cus_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cus_id"));

                    b.Property<string>("Cus_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cus_phone")
                        .HasColumnType("int");

                    b.Property<int?>("HotelsHotel_Id")
                        .HasColumnType("int");

                    b.HasKey("Cus_id");

                    b.HasIndex("HotelsHotel_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("hotel.models.HotelRooms", b =>
                {
                    b.Property<int>("Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_Id"));

                    b.Property<int?>("HotelsHotel_Id")
                        .HasColumnType("int");

                    b.Property<string>("Room_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Room_Id");

                    b.HasIndex("HotelsHotel_Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("hotel.models.HotelStaffs", b =>
                {
                    b.Property<int>("Staff_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Staff_Id"));

                    b.Property<int?>("HotelsHotel_Id")
                        .HasColumnType("int");

                    b.Property<string>("Staff_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Staff_Id");

                    b.HasIndex("HotelsHotel_Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("hotel.models.Hotels", b =>
                {
                    b.Property<int>("Hotel_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hotel_Id"));

                    b.Property<string>("Hotel_Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hotel_Price")
                        .HasColumnType("int");

                    b.Property<string>("Hotel_amenities")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hotel_Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("hotel.models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("User_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("hotel.models.HotelCustomers", b =>
                {
                    b.HasOne("hotel.models.Hotels", "Hotels")
                        .WithMany("Hotel_Customers")
                        .HasForeignKey("HotelsHotel_Id");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("hotel.models.HotelRooms", b =>
                {
                    b.HasOne("hotel.models.Hotels", "Hotels")
                        .WithMany("Hotel_Rooms")
                        .HasForeignKey("HotelsHotel_Id");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("hotel.models.HotelStaffs", b =>
                {
                    b.HasOne("hotel.models.Hotels", "Hotels")
                        .WithMany("Hotel_Staffs")
                        .HasForeignKey("HotelsHotel_Id");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("hotel.models.Hotels", b =>
                {
                    b.Navigation("Hotel_Customers");

                    b.Navigation("Hotel_Rooms");

                    b.Navigation("Hotel_Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}