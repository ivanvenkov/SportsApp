using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace FootballDataAccess.Migrations
{
    public partial class ini100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FOOTBALL_PERSON_SPORT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOOTBALL_PERSON_SPORT", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FOOTBALL_PERSON_SPORT");
        }
    }
}
