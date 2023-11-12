using BGS.ApplicationCore.Games.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGS.Infrastructure.Data.Migrations
{
    public partial class AddBattleForRokuganGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.Sql($@"
                INSERT INTO game(id, name, key)
                VALUES (uuid_generate_v4(), 'Battle for Rokugan', '{GameKeys.BattleForRokugan}');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
