using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKhamNhaKhoa.Api.Migrations
{
    public partial class Identiti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoleClaim",
                table: "AppUserRoleClaim");

            migrationBuilder.RenameTable(
                name: "AppUserRoleClaim",
                newName: "AppRoleClaim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoleClaim",
                table: "AppRoleClaim",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoleClaim",
                table: "AppRoleClaim");

            migrationBuilder.RenameTable(
                name: "AppRoleClaim",
                newName: "AppUserRoleClaim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoleClaim",
                table: "AppUserRoleClaim",
                column: "Id");
        }
    }
}
