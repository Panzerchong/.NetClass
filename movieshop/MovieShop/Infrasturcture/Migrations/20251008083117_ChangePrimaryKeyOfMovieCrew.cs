using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrimaryKeyOfMovieCrew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_MovieCast_MovieCastMovieId_MovieCastCastId",
                table: "MovieCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_MovieCastMovieId_MovieCastCastId",
                table: "MovieCast");

            migrationBuilder.AddColumn<string>(
                name: "MovieCastCharacter",
                table: "MovieCast",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "MovieId", "CastId", "Character" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieCastMovieId_MovieCastCastId_MovieCastCharacter",
                table: "MovieCast",
                columns: new[] { "MovieCastMovieId", "MovieCastCastId", "MovieCastCharacter" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_MovieCast_MovieCastMovieId_MovieCastCastId_MovieCastCharacter",
                table: "MovieCast",
                columns: new[] { "MovieCastMovieId", "MovieCastCastId", "MovieCastCharacter" },
                principalTable: "MovieCast",
                principalColumns: new[] { "MovieId", "CastId", "Character" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_MovieCast_MovieCastMovieId_MovieCastCastId_MovieCastCharacter",
                table: "MovieCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_MovieCastMovieId_MovieCastCastId_MovieCastCharacter",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "MovieCastCharacter",
                table: "MovieCast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "MovieId", "CastId" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieCastMovieId_MovieCastCastId",
                table: "MovieCast",
                columns: new[] { "MovieCastMovieId", "MovieCastCastId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_MovieCast_MovieCastMovieId_MovieCastCastId",
                table: "MovieCast",
                columns: new[] { "MovieCastMovieId", "MovieCastCastId" },
                principalTable: "MovieCast",
                principalColumns: new[] { "MovieId", "CastId" });
        }
    }
}
