using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGS.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(65)", maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game", x => x.game_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
