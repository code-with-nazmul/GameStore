using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixReleaseTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelseaseDate",
                table: "Games",
                newName: "ReleaseDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Games",
                newName: "RelseaseDate");
        }
    }
}
