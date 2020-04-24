using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200423_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_noun_specification_word_pattern_word_id",
                table: "cs_word_noun_specification");

            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_noun_specification_word_word_id",
                table: "cs_word_noun_specification");

            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_uni_specification_word_word_id",
                table: "cs_word_uni_specification");

            migrationBuilder.DropForeignKey(
                name: "fk_word_meaning_word_word_id",
                table: "word_meaning");

            migrationBuilder.DropPrimaryKey(
                name: "pk_word",
                table: "word");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cs_word_uni_specification",
                table: "cs_word_uni_specification");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cs_word_noun_specification",
                table: "cs_word_noun_specification");

            migrationBuilder.DropPrimaryKey(
                name: "pk_crawler_website",
                table: "crawler_website");

            migrationBuilder.RenameTable(
                name: "word",
                newName: "words");

            migrationBuilder.RenameTable(
                name: "cs_word_uni_specification",
                newName: "cs_word_uni_specifications");

            migrationBuilder.RenameTable(
                name: "cs_word_noun_specification",
                newName: "cs_word_noun_specifications");

            migrationBuilder.RenameTable(
                name: "crawler_website",
                newName: "crawler_websites");

            migrationBuilder.RenameIndex(
                name: "ix_word_text_lang",
                table: "words",
                newName: "ix_words_text_lang");

            migrationBuilder.RenameIndex(
                name: "ix_word_id",
                table: "words",
                newName: "ix_words_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_uni_specification_word_id",
                table: "cs_word_uni_specifications",
                newName: "ix_cs_word_uni_specifications_word_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_uni_specification_id",
                table: "cs_word_uni_specifications",
                newName: "ix_cs_word_uni_specifications_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_noun_specification_word_id_gender_declension_pl1_de",
                table: "cs_word_noun_specifications",
                newName: "ix_cs_word_noun_specifications_word_id_gender_declension_pl1_d");

            // migrationBuilder.RenameIndex(
            //     name: "ix_cs_word_noun_specification_pattern_word_id",
            //     table: "cs_word_noun_specifications",
            //     newName: "ix_cs_word_noun_specifications_pattern_word_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_noun_specification_id",
                table: "cs_word_noun_specifications",
                newName: "ix_cs_word_noun_specifications_id");

            migrationBuilder.RenameIndex(
                name: "ix_crawler_website_id",
                table: "crawler_websites",
                newName: "ix_crawler_websites_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_words",
                table: "words",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cs_word_uni_specifications",
                table: "cs_word_uni_specifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cs_word_noun_specifications",
                table: "cs_word_noun_specifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_crawler_websites",
                table: "crawler_websites",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_noun_specifications_words_pattern_word_id",
                table: "cs_word_noun_specifications",
                column: "pattern_word_id",
                principalTable: "words",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_noun_specifications_words_word_id",
                table: "cs_word_noun_specifications",
                column: "word_id",
                principalTable: "words",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_uni_specifications_words_word_id",
                table: "cs_word_uni_specifications",
                column: "word_id",
                principalTable: "words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_word_meaning_words_word_id",
                table: "word_meaning",
                column: "word_id",
                principalTable: "words",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_noun_specifications_words_pattern_word_id",
                table: "cs_word_noun_specifications");

            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_noun_specifications_words_word_id",
                table: "cs_word_noun_specifications");

            migrationBuilder.DropForeignKey(
                name: "fk_cs_word_uni_specifications_words_word_id",
                table: "cs_word_uni_specifications");

            migrationBuilder.DropForeignKey(
                name: "fk_word_meaning_words_word_id",
                table: "word_meaning");

            migrationBuilder.DropPrimaryKey(
                name: "pk_words",
                table: "words");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cs_word_uni_specifications",
                table: "cs_word_uni_specifications");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cs_word_noun_specifications",
                table: "cs_word_noun_specifications");

            migrationBuilder.DropPrimaryKey(
                name: "pk_crawler_websites",
                table: "crawler_websites");

            migrationBuilder.RenameTable(
                name: "words",
                newName: "word");

            migrationBuilder.RenameTable(
                name: "cs_word_uni_specifications",
                newName: "cs_word_uni_specification");

            migrationBuilder.RenameTable(
                name: "cs_word_noun_specifications",
                newName: "cs_word_noun_specification");

            migrationBuilder.RenameTable(
                name: "crawler_websites",
                newName: "crawler_website");

            migrationBuilder.RenameIndex(
                name: "ix_words_text_lang",
                table: "word",
                newName: "ix_word_text_lang");

            migrationBuilder.RenameIndex(
                name: "ix_words_id",
                table: "word",
                newName: "ix_word_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_uni_specifications_word_id",
                table: "cs_word_uni_specification",
                newName: "ix_cs_word_uni_specification_word_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_uni_specifications_id",
                table: "cs_word_uni_specification",
                newName: "ix_cs_word_uni_specification_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_noun_specifications_word_id_gender_declension_pl1_d",
                table: "cs_word_noun_specification",
                newName: "ix_cs_word_noun_specification_word_id_gender_declension_pl1_de");

            // migrationBuilder.RenameIndex(
            //     name: "ix_cs_word_noun_specifications_pattern_word_id",
            //     table: "cs_word_noun_specification",
            //     newName: "ix_cs_word_noun_specification_pattern_word_id");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_noun_specifications_id",
                table: "cs_word_noun_specification",
                newName: "ix_cs_word_noun_specification_id");

            migrationBuilder.RenameIndex(
                name: "ix_crawler_websites_id",
                table: "crawler_website",
                newName: "ix_crawler_website_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_word",
                table: "word",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cs_word_uni_specification",
                table: "cs_word_uni_specification",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cs_word_noun_specification",
                table: "cs_word_noun_specification",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_crawler_website",
                table: "crawler_website",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_noun_specification_word_pattern_word_id",
                table: "cs_word_noun_specification",
                column: "pattern_word_id",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_noun_specification_word_word_id",
                table: "cs_word_noun_specification",
                column: "word_id",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_cs_word_uni_specification_word_word_id",
                table: "cs_word_uni_specification",
                column: "word_id",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_word_meaning_word_word_id",
                table: "word_meaning",
                column: "word_id",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
