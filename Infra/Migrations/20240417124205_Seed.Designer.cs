﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20240417124205_Seed")]
    partial class Seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Course", b =>
                {
                    b.Property<long>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CourseID"));

                    b.Property<string>("Benifits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInHours")
                        .HasColumnType("int");

                    b.Property<string>("Prerequisite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SubjectID")
                        .HasColumnType("bigint");

                    b.HasKey("CourseID");

                    b.HasIndex("SubjectID");

                    b.ToTable("CourseTbl");
                });

            modelBuilder.Entity("Core.Order", b =>
                {
                    b.Property<long>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderID"));

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("OrderTbl");
                });

            modelBuilder.Entity("Core.OrderDet", b =>
                {
                    b.Property<long>("OrderDetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderDetID"));

                    b.Property<long>("CourseID")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetID");

                    b.HasIndex("CourseID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDets");
                });

            modelBuilder.Entity("Core.Subject", b =>
                {
                    b.Property<long>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SubjectID"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SubjectStreamID")
                        .HasColumnType("bigint");

                    b.HasKey("SubjectID");

                    b.HasIndex("SubjectStreamID");

                    b.ToTable("SubjecTbl");
                });

            modelBuilder.Entity("Core.SubjectStream", b =>
                {
                    b.Property<long>("SubjectStreamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SubjectStreamID"));

                    b.Property<string>("StreamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectStreamID");

                    b.ToTable("SubjectStreamTbl");
                });

            modelBuilder.Entity("Core.TrainingCompany", b =>
                {
                    b.Property<long>("TrainingCompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TrainingCompanyID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingCompanyID");

                    b.ToTable("TrainingCompanies");

                    b.HasData(
                        new
                        {
                            TrainingCompanyID = 1L,
                            Address = "Akurdi Pune",
                            CompanyName = "RI-TECH",
                            EmailID = "contact@ritehcpune.com",
                            MobileNo = "978686787686",
                            Password = "abcd",
                            WebsiteUrl = "https://www.ritechpune.com"
                        });
                });

            modelBuilder.Entity("Core.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserTbl");
                });

            modelBuilder.Entity("Core.Course", b =>
                {
                    b.HasOne("Core.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Core.Order", b =>
                {
                    b.HasOne("Core.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.OrderDet", b =>
                {
                    b.HasOne("Core.Course", "Course")
                        .WithMany("OrderDets")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Order", "Order")
                        .WithMany("OrderDets")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Core.Subject", b =>
                {
                    b.HasOne("Core.SubjectStream", "Stream")
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectStreamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stream");
                });

            modelBuilder.Entity("Core.Course", b =>
                {
                    b.Navigation("OrderDets");
                });

            modelBuilder.Entity("Core.Order", b =>
                {
                    b.Navigation("OrderDets");
                });

            modelBuilder.Entity("Core.Subject", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Core.SubjectStream", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Core.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
