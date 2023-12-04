using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeOfGameNamePropertyToCitext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "game",
                type: "citext",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(65)",
                oldMaxLength: 65);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "game",
                type: "character varying(65)",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "citext",
                oldMaxLength: 65);
        }
    }
}
