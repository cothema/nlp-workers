using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200423_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ix_cs_word_noun_specification_pattern_word_id",
                table: "cs_word_noun_specification");

            migrationBuilder.DropForeignKey(
                name: "ix_cs_word_noun_specification_word_id",
                table: "cs_word_noun_specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_word",
                table: "word");

            migrationBuilder.DropUniqueConstraint(
                "word_pk_2",
                "word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cs_word_uni_specification",
                table: "cs_word_uni_specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cs_word_noun_specification",
                table: "cs_word_noun_specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_crawler_website",
                table: "crawler_website");

            migrationBuilder.RenameIndex(
                name: "word_word_lang_uindex",
                table: "word",
                newName: "ix_word_text_lang");

            migrationBuilder.RenameIndex(
                name: "word_id_uindex",
                table: "word",
                newName: "ix_word_id");

            migrationBuilder.RenameIndex(
                name: "cs_word_uni_specification_word_id_uindex",
                table: "cs_word_uni_specification",
                newName: "ix_cs_word_uni_specification_word_id");

            migrationBuilder.RenameIndex(
                name: "cs_word_uni_specification_id_uindex",
                table: "cs_word_uni_specification",
                newName: "ix_cs_word_uni_specification_id");

            migrationBuilder.RenameIndex(
                name: "cs_word_noun_specification_ui",
                table: "cs_word_noun_specification",
                newName: "ix_cs_word_noun_specification_word_id_gender_declension_pl1_de");

            migrationBuilder.RenameIndex(
                name: "word_declension_id_uindex",
                table: "cs_word_noun_specification",
                newName: "ix_cs_word_noun_specification_id");

            migrationBuilder.AlterColumn<string>(
                name: "url",
                table: "crawler_website",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "crawled",
                table: "crawler_website",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

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

            migrationBuilder.CreateTable(
                name: "meanings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wikipedia_url = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("pk_meanings", x => x.id); });

            migrationBuilder.CreateTable(
                name: "word_meaning",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word_id = table.Column<int>(nullable: false),
                    meaning_id = table.Column<int>(nullable: false),
                    note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_meaning", x => x.id);
                    table.ForeignKey(
                        name: "fk_word_meaning_meanings_meaning_id",
                        column: x => x.meaning_id,
                        principalTable: "meanings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_word_meaning_word_word_id",
                        column: x => x.word_id,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_crawler_website_id",
                table: "crawler_website",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_meanings_id",
                table: "meanings",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_word_meaning_id",
                table: "word_meaning",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_word_meaning_meaning_id",
                table: "word_meaning",
                column: "meaning_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_meaning_word_id",
                table: "word_meaning",
                column: "word_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "word_meaning");

            migrationBuilder.DropTable(
                name: "meanings");

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

            migrationBuilder.DropIndex(
                name: "ix_crawler_website_id",
                table: "crawler_website");

            migrationBuilder.RenameIndex(
                name: "ix_word_text_lang",
                table: "word",
                newName: "word_word_lang_uindex");

            migrationBuilder.RenameIndex(
                name: "ix_word_id",
                table: "word",
                newName: "word_id_uindex");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_uni_specification_word_id",
                table: "cs_word_uni_specification",
                newName: "cs_word_uni_specification_word_id_uindex");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_uni_specification_id",
                table: "cs_word_uni_specification",
                newName: "cs_word_uni_specification_id_uindex");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_noun_specification_word_id_gender_declension_pl1_de",
                table: "cs_word_noun_specification",
                newName: "cs_word_noun_specification_ui");

            migrationBuilder.RenameIndex(
                name: "ix_cs_word_noun_specification_id",
                table: "cs_word_noun_specification",
                newName: "word_declension_id_uindex");

            migrationBuilder.AlterColumn<string>(
                name: "url",
                table: "crawler_website",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "crawled",
                table: "crawler_website",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_word",
                table: "word",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cs_word_uni_specification",
                table: "cs_word_uni_specification",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cs_word_noun_specification",
                table: "cs_word_noun_specification",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_crawler_website",
                table: "crawler_website",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "word_pk_2",
                table: "word",
                column: "text",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "ix_cs_word_noun_specification_pattern_word_id",
                table: "cs_word_noun_specification",
                column: "pattern_word_id",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "ix_cs_word_noun_specification_word_id",
                table: "cs_word_noun_specification",
                column: "word_id",
                principalTable: "word",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}