using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieInfo.InternalApi.Migrations
{
    public partial class AddFieldsToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movie",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RealeseDate",
                table: "Movie",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "RealeseDate",
                table: "Movie");
        }
    }
}
