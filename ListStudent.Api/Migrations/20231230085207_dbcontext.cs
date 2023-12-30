using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKhamNhaKhoa.Api.Migrations
{
    public partial class dbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberPhone = table.Column<int>(type: "int", nullable: false),
                    AddressKH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<int>(type: "int", nullable: false),
                    AddressNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongKhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongKhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuKhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDichVu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhongKham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuKhams_DichVus_IdDichVu",
                        column: x => x.IdDichVu,
                        principalTable: "DichVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuKhams_KhachHangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuKhams_NhanViens_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuKhams_PhongKhams_IdPhongKham",
                        column: x => x.IdPhongKham,
                        principalTable: "PhongKhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhams_IdDichVu",
                table: "PhieuKhams",
                column: "IdDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhams_IdKhachHang",
                table: "PhieuKhams",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhams_IdNhanVien",
                table: "PhieuKhams",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhams_IdPhongKham",
                table: "PhieuKhams",
                column: "IdPhongKham");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuKhams");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "PhongKhams");
        }
    }
}
