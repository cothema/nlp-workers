using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nlp20Crawler.Migrations
{
    public partial class _20200424 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "crawler_meaning_check_proposed",
                table: "words",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "crawler_meaning_check_proposed_time",
                table: "words",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "crawler_meaning_check_proposed",
                table: "words");

            migrationBuilder.DropColumn(
                name: "crawler_meaning_check_proposed_time",
                table: "words");
        }
    }
}
