using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_QLHoSo_So.Model.Migrations
{
    /// <inheritdoc />
    public partial class sdsds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "tbl_User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "tbl_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "tbl_User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "tbl_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "tbl_User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "tbl_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "tbl_User");
        }
    }
}
