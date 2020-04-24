using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200424_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lemma_word_id",
                table: "cs_word_uni_specifications",
                nullable: false,
                defaultValue: 0,
                comment: "Word in basic representative form used for dictionaries.");

            migrationBuilder.CreateIndex(
                name: "ix_cs_word_uni_specifications_lemma_word_id",
                table: "cs_word_uni_specifications",
                column: "lemma_word_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_uni_specifications_words_lemma_word_id",
                table: "cs_word_uni_specifications",
                column: "lemma_word_id",
                principalTable: "words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            
            // Manually added extension required for random sort
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_uni_specifications_words_lemma_word_id",
                table: "cs_word_uni_specifications");

            migrationBuilder.DropIndex(
                name: "ix_cs_word_uni_specifications_lemma_word_id",
                table: "cs_word_uni_specifications");

            migrationBuilder.DropColumn(
                name: "lemma_word_id",
                table: "cs_word_uni_specifications");
        }
    }
}
