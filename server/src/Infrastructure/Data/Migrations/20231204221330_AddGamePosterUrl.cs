using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGamePosterUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "poster_url",
                table: "game",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "poster_url",
                table: "game");
        }
    }
}
