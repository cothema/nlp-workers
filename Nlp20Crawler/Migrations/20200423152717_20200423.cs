using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200423 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "crawler_website",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(nullable: true),
                    crawled = table.Column<bool>(nullable: false),
                    crawled_timestamp = table.Column<DateTime>(nullable: true),
                    html = table.Column<string>(nullable: true),
                    response_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("crawler_website_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cs_word_uni_specification",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word_id = table.Column<int>(nullable: false),
                    is_negative = table.Column<bool>(nullable: true, comment: "true: is negative, false: is positive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("cs_word_uni_specification_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "word",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(nullable: false),
                    lang = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("word_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cs_word_noun_specification",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word_id = table.Column<int>(nullable: false),
                    gender = table.Column<short>(nullable: true, comment: "0:male,1:female,2:it"),
                    declension_sg1 = table.Column<bool>(nullable: true),
                    declension_sg2 = table.Column<bool>(nullable: true),
                    declension_sg3 = table.Column<bool>(nullable: true),
                    declension_sg4 = table.Column<bool>(nullable: true),
                    declension_sg5 = table.Column<bool>(nullable: true),
                    declension_sg6 = table.Column<bool>(nullable: true),
                    declension_sg7 = table.Column<bool>(nullable: true),
                    declension_pl1 = table.Column<bool>(nullable: true),
                    declension_pl2 = table.Column<bool>(nullable: true),
                    declension_pl3 = table.Column<bool>(nullable: true),
                    declension_pl4 = table.Column<bool>(nullable: true),
                    declension_pl5 = table.Column<bool>(nullable: true),
                    declension_pl6 = table.Column<bool>(nullable: true),
                    declension_pl7 = table.Column<bool>(nullable: true),
                    verified_by_human = table.Column<bool>(nullable: false),
                    verified_reliability = table.Column<int>(nullable: true, comment: "0: absolutely not verified, 100: verified by professional human"),
                    pattern_word_id = table.Column<int>(nullable: true),
                    life = table.Column<bool>(nullable: true, comment: "false: non life, true: life (for male patterns only)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("cs_word_noun_specification_pk", x => x.id);
                    table.ForeignKey(
                        name: "ix_cs_word_noun_specification_pattern_word_id",
                        column: x => x.pattern_word_id,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ix_cs_word_noun_specification_word_id",
                        column: x => x.word_id,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "word_declension_id_uindex",
                table: "cs_word_noun_specification",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_cs_word_noun_specification_pattern_word_id",
                table: "cs_word_noun_specification",
                column: "pattern_word_id");

            migrationBuilder.CreateIndex(
                name: "cs_word_noun_specification_ui",
                table: "cs_word_noun_specification",
                columns: new[] { "word_id", "gender", "declension_pl1", "declension_pl2", "declension_pl3", "declension_pl4", "declension_pl5", "declension_pl6", "declension_pl7", "declension_sg1", "declension_sg2", "declension_sg3", "declension_sg4", "declension_sg5", "declension_sg6", "declension_sg7", "pattern_word_id", "life" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "cs_word_uni_specification_id_uindex",
                table: "cs_word_uni_specification",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "cs_word_uni_specification_word_id_uindex",
                table: "cs_word_uni_specification",
                column: "word_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "word_id_uindex",
                table: "word",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "word_pk_2",
                table: "word",
                column: "text",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "word_word_lang_uindex",
                table: "word",
                columns: new[] { "text", "lang" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crawler_website");

            migrationBuilder.DropTable(
                name: "cs_word_noun_specification");

            migrationBuilder.DropTable(
                name: "cs_word_uni_specification");

            migrationBuilder.DropTable(
                name: "word");
        }
    }
}
