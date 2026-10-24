using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenreModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Genres",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "id");
        }
    }
}
