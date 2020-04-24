using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200424_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "crawler_meaning_check_proposed",
                table: "words",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<bool>(
                name: "crawler_proposed_wiki",
                table: "cs_word_noun_specifications",
                nullable: true,
                comment: "null: not checked by proposer, false: not proposed, true: proposed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "crawler_proposed_wiki",
                table: "cs_word_noun_specifications");

            migrationBuilder.AlterColumn<bool>(
                name: "crawler_meaning_check_proposed",
                table: "words",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
