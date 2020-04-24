using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200424_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "occurence_count",
                table: "words",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "is_negative",
                table: "cs_word_uni_specifications",
                nullable: true,
                comment: "null: N/A / true: is negative / false: is positive",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldComment: "true: is negative, false: is positive");

            migrationBuilder.AddColumn<int>(
                name: "verbal_type",
                table: "cs_word_uni_specifications",
                maxLength: 1,
                nullable: false,
                defaultValue: 0,
                comment: "0: interjection, 1 - 9: noun - adverb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "occurence_count",
                table: "words");

            migrationBuilder.DropColumn(
                name: "verbal_type",
                table: "cs_word_uni_specifications");

            migrationBuilder.AlterColumn<bool>(
                name: "is_negative",
                table: "cs_word_uni_specifications",
                type: "boolean",
                nullable: true,
                comment: "true: is negative, false: is positive",
                oldClrType: typeof(bool),
                oldNullable: true,
                oldComment: "null: N/A / true: is negative / false: is positive");
        }
    }
}
