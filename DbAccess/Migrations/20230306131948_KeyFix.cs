using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    /// <inheritdoc />
    public partial class KeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_User_Id",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Notes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_User_Id",
                table: "Notes",
                newName: "IX_Notes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notes",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                newName: "IX_Notes_User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_User_Id",
                table: "Notes",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
