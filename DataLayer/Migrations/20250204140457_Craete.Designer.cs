﻿// <auto-generated />
using System;
using DataLayer.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(library_management_systemDB))]
    [Migration("20250204140457_Craete")]
    partial class Craete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Models.Book", b =>
                {
                    b.Property<int>("BookNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookNumber"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookNumber");

                    b.ToTable("T_Book");
                });

            modelBuilder.Entity("DataLayer.Models.Circulated", b =>
                {
                    b.Property<int>("CirculatedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CirculatedID"));

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CopyNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("FineAmount")
                        .HasColumnType("float");

                    b.Property<int>("MemberNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CirculatedID");

                    b.HasIndex("CopyNumber");

                    b.HasIndex("MemberNumber");

                    b.ToTable("T_Circulated");
                });

            modelBuilder.Entity("DataLayer.Models.Copy", b =>
                {
                    b.Property<int>("CopyNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopyNumber"));

                    b.Property<int>("BookNumber")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CopyNumber");

                    b.HasIndex("BookNumber");

                    b.ToTable("T_Copy");
                });

            modelBuilder.Entity("DataLayer.Models.Member", b =>
                {
                    b.Property<int>("MemberNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberNumber"));

                    b.Property<string>("Addess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberNumber");

                    b.ToTable("T_Member");
                });

            modelBuilder.Entity("DataLayer.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("CopyNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("CopyNumber");

                    b.HasIndex("MemberNumber");

                    b.ToTable("T_Reservation");
                });

            modelBuilder.Entity("DataLayer.Models.Circulated", b =>
                {
                    b.HasOne("DataLayer.Models.Copy", "copy")
                        .WithMany("Circulated")
                        .HasForeignKey("CopyNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Member", "member")
                        .WithMany("Circulated")
                        .HasForeignKey("MemberNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("copy");

                    b.Navigation("member");
                });

            modelBuilder.Entity("DataLayer.Models.Copy", b =>
                {
                    b.HasOne("DataLayer.Models.Book", "book")
                        .WithMany("Copy")
                        .HasForeignKey("BookNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");
                });

            modelBuilder.Entity("DataLayer.Models.Reservation", b =>
                {
                    b.HasOne("DataLayer.Models.Copy", "copy")
                        .WithMany("Reservation")
                        .HasForeignKey("CopyNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Member", "member")
                        .WithMany("Reservation")
                        .HasForeignKey("MemberNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("copy");

                    b.Navigation("member");
                });

            modelBuilder.Entity("DataLayer.Models.Book", b =>
                {
                    b.Navigation("Copy");
                });

            modelBuilder.Entity("DataLayer.Models.Copy", b =>
                {
                    b.Navigation("Circulated");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("DataLayer.Models.Member", b =>
                {
                    b.Navigation("Circulated");

                    b.Navigation("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
