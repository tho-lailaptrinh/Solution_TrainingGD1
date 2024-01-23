using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKhamNhaKhoa.Api.Migrations
{
    public partial class dbcontextss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdImage",
                table: "KhachHangs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "KhachHangs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ImageFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_IdImage",
                table: "KhachHangs",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_IdUser",
                table: "KhachHangs",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHangs_AspNetUsers_IdUser",
                table: "KhachHangs",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHangs_ImageFiles_IdImage",
                table: "KhachHangs",
                column: "IdImage",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHangs_AspNetUsers_IdUser",
                table: "KhachHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_KhachHangs_ImageFiles_IdImage",
                table: "KhachHangs");

            migrationBuilder.DropTable(
                name: "ImageFiles");

            migrationBuilder.DropIndex(
                name: "IX_KhachHangs_IdImage",
                table: "KhachHangs");

            migrationBuilder.DropIndex(
                name: "IX_KhachHangs_IdUser",
                table: "KhachHangs");

            migrationBuilder.DropColumn(
                name: "IdImage",
                table: "KhachHangs");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "KhachHangs");
        }
    }
}
