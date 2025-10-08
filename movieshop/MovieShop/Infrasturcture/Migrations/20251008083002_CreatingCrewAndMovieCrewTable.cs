using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class CreatingCrewAndMovieCrewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TmdbUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(2084)", maxLength: 2084, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCrew",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Job = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MovieCrewCrewId = table.Column<int>(type: "int", nullable: true),
                    MovieCrewDepartment = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    MovieCrewJob = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    MovieCrewMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCrew", x => new { x.MovieId, x.CrewId, x.Department, x.Job });
                    table.ForeignKey(
                        name: "FK_MovieCrew_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCrew_MovieCrew_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                        columns: x => new { x.MovieCrewMovieId, x.MovieCrewCrewId, x.MovieCrewDepartment, x.MovieCrewJob },
                        principalTable: "MovieCrew",
                        principalColumns: new[] { "MovieId", "CrewId", "Department", "Job" });
                    table.ForeignKey(
                        name: "FK_MovieCrew_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrew_CrewId",
                table: "MovieCrew",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrew_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "MovieCrew",
                columns: new[] { "MovieCrewMovieId", "MovieCrewCrewId", "MovieCrewDepartment", "MovieCrewJob" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCrew");

            migrationBuilder.DropTable(
                name: "Crews");
        }
    }
}
