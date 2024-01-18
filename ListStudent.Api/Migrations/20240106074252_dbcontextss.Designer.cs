﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhongKhamNhaKhoa.Api.Data;

namespace PhongKhamNhaKhoa.Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240106074252_dbcontextss")]
    partial class dbcontextss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.DichVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DichVus");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressKH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("StatusKH")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressNV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberPhone")
                        .HasColumnType("int");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.PhieuKham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdDichVu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdKhachHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNhanVien")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPhongKham")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDichVu");

                    b.HasIndex("IdKhachHang");

                    b.HasIndex("IdNhanVien");

                    b.HasIndex("IdPhongKham");

                    b.ToTable("PhieuKhams");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.PhongKham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PhongKhams");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.PhieuKham", b =>
                {
                    b.HasOne("PhongKhamNhaKhoa.Api.Entitis.DichVu", "DichVus")
                        .WithMany("PhieuKhams")
                        .HasForeignKey("IdDichVu");

                    b.HasOne("PhongKhamNhaKhoa.Api.Entitis.KhachHang", "KhachHang")
                        .WithMany("PhieuKhams")
                        .HasForeignKey("IdKhachHang");

                    b.HasOne("PhongKhamNhaKhoa.Api.Entitis.NhanVien", "NhanViens")
                        .WithMany("PhieuKhams")
                        .HasForeignKey("IdNhanVien");

                    b.HasOne("PhongKhamNhaKhoa.Api.Entitis.PhongKham", "PhongKham")
                        .WithMany("PhieuKhams")
                        .HasForeignKey("IdPhongKham");

                    b.Navigation("DichVus");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanViens");

                    b.Navigation("PhongKham");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.DichVu", b =>
                {
                    b.Navigation("PhieuKhams");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.KhachHang", b =>
                {
                    b.Navigation("PhieuKhams");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.NhanVien", b =>
                {
                    b.Navigation("PhieuKhams");
                });

            modelBuilder.Entity("PhongKhamNhaKhoa.Api.Entitis.PhongKham", b =>
                {
                    b.Navigation("PhieuKhams");
                });
#pragma warning restore 612, 618
        }
    }
}
