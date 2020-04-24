using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200424_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "probability",
                table: "words",
                maxLength: 3,
                nullable: false,
                defaultValue: 0,
                comment: "-100 - +100 (-100 means not possible, 100 means 100% probability)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "probability",
                table: "words");
        }
    }
}
