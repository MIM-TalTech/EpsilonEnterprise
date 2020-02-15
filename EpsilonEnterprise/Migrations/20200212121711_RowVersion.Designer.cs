﻿// <auto-generated />
using System;
using EpsilonEnterprise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EpsilonEnterprise.Migrations
{
    [DbContext(typeof(BusinessContext))]
    [Migration("20200212121711_RowVersion")]
    partial class RowVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EpsilonEnterprise.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int?>("OfficeAssignmentBossID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AssignmentID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("OfficeAssignmentBossID");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.AssignmentAssignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<int>("BossID")
                        .HasColumnType("int");

                    b.HasKey("AssignmentID", "BossID");

                    b.HasIndex("AssignmentID")
                        .IsUnique();

                    b.HasIndex("BossID");

                    b.ToTable("AssignmentAssignment");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Boss", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Boss");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BossID")
                        .HasColumnType("int");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DepartmentID");

                    b.HasIndex("BossID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("Pay")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("BossID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BossID");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Assignment", b =>
                {
                    b.HasOne("EpsilonEnterprise.Models.Department", "Department")
                        .WithMany("Assignments")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpsilonEnterprise.Models.OfficeAssignment", "OfficeAssignment")
                        .WithMany()
                        .HasForeignKey("OfficeAssignmentBossID");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.AssignmentAssignment", b =>
                {
                    b.HasOne("EpsilonEnterprise.Models.Assignment", "Assignment")
                        .WithOne("AssignmentAssignments")
                        .HasForeignKey("EpsilonEnterprise.Models.AssignmentAssignment", "AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpsilonEnterprise.Models.Boss", "Boss")
                        .WithMany("AssignmentAssignments")
                        .HasForeignKey("BossID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Department", b =>
                {
                    b.HasOne("EpsilonEnterprise.Models.Boss", "Boss")
                        .WithMany()
                        .HasForeignKey("BossID");
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.Enrollment", b =>
                {
                    b.HasOne("EpsilonEnterprise.Models.Assignment", "Assignment")
                        .WithMany("Enrollments")
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EpsilonEnterprise.Models.Employee", "Employee")
                        .WithMany("Enrollments")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EpsilonEnterprise.Models.OfficeAssignment", b =>
                {
                    b.HasOne("EpsilonEnterprise.Models.Boss", "Boss")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("EpsilonEnterprise.Models.OfficeAssignment", "BossID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
