using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                table: "User",
                newName: "LastLoginDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLoginDateTime",
                table: "User",
                newName: "LastLoginDate");
        }
    }
}
