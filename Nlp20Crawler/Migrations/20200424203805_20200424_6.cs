using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200424_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "word_id",
                table: "crawler_websites",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_crawler_websites_word_id",
                table: "crawler_websites",
                column: "word_id");

            migrationBuilder.AddForeignKey(
                name: "fk_crawler_websites_words_word_id",
                table: "crawler_websites",
                column: "word_id",
                principalTable: "words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_crawler_websites_words_word_id",
                table: "crawler_websites");

            migrationBuilder.DropIndex(
                name: "ix_crawler_websites_word_id",
                table: "crawler_websites");

            migrationBuilder.DropColumn(
                name: "word_id",
                table: "crawler_websites");
        }
    }
}
