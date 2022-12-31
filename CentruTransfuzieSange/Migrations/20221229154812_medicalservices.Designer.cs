﻿// <auto-generated />
using System;
using CentruTransfuzieSange.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CentruTransfuzieSange.Migrations
{
    [DbContext(typeof(CentruTransfuzieSangeContext))]
    [Migration("20221229154812_medicalservices")]
    partial class medicalservices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CentruTransfuzieSange.Models.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MedicalService")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalServicesID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MedicalServicesID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.MedicalService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("MedicalService");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.Appointment", b =>
                {
                    b.HasOne("CentruTransfuzieSange.Models.MedicalService", "MedicalServices")
                        .WithMany()
                        .HasForeignKey("MedicalServicesID");

                    b.HasOne("CentruTransfuzieSange.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID");

                    b.Navigation("MedicalServices");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.MedicalService", b =>
                {
                    b.HasOne("CentruTransfuzieSange.Models.Doctor", "Doctor")
                        .WithMany("MedicalServices")
                        .HasForeignKey("DoctorID");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.Doctor", b =>
                {
                    b.Navigation("MedicalServices");
                });

            modelBuilder.Entity("CentruTransfuzieSange.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}