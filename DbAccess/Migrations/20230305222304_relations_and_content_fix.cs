using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    /// <inheritdoc />
    public partial class relations_and_content_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Notes",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_UserID",
                table: "Notes",
                newName: "IX_Notes_User_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_User_Id",
                table: "Notes",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_User_Id",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Notes",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_User_Id",
                table: "Notes",
                newName: "IX_Notes_UserID");

            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
