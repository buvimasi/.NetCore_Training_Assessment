﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Training.Domain.Data;

#nullable disable

namespace Training.Domain.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20220913101808_usertable")]
    partial class usertable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Training.Domain.Entities.Employees", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<decimal>("Experience")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LockStatus")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("lockstatus");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("manager");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("profile_Id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("status");

                    b.Property<string>("Wfm_Manager")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("wfm_manager");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Training.Domain.Entities.SkillMap", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_Id");

                    b.Property<int>("SkillId")
                        .HasColumnType("int")
                        .HasColumnName("skillId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillMaps");
                });

            modelBuilder.Entity("Training.Domain.Entities.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("skillId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Training.Domain.Entities.SoftLock", b =>
                {
                    b.Property<int>("LockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("lockId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LockId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_Id");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2")
                        .HasColumnName("lastupdated");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("manager");

                    b.Property<string>("ManagerStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("managerstatus");

                    b.Property<string>("MgrLastupdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mgrlastupdate");

                    b.Property<string>("MgrStatuscomment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mgrstatuscomment");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("reqdate");

                    b.Property<string>("RequestMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("requestmessage");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<string>("Wfmremark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("wfmremark");

                    b.HasKey("LockId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SoftLocks");
                });

            modelBuilder.Entity("Training.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Training.Domain.Entities.SkillMap", b =>
                {
                    b.HasOne("Training.Domain.Entities.Employees", "Employees")
                        .WithMany("SkillMaps")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Training.Domain.Entities.Skills", "Skills")
                        .WithMany("SkillMaps")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Training.Domain.Entities.SoftLock", b =>
                {
                    b.HasOne("Training.Domain.Entities.Employees", "Employees")
                        .WithMany("SoftLocks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Training.Domain.Entities.Employees", b =>
                {
                    b.Navigation("SkillMaps");

                    b.Navigation("SoftLocks");
                });

            modelBuilder.Entity("Training.Domain.Entities.Skills", b =>
                {
                    b.Navigation("SkillMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
