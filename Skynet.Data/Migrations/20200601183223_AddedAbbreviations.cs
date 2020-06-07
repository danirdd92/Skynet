using Microsoft.EntityFrameworkCore.Migrations;

namespace Skynet.Data.Migrations
{
    public partial class AddedAbbreviations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Airlines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Airlines");
        }
    }
}
