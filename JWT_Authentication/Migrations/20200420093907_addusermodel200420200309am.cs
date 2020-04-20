using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWT_Authentication.Migrations
{
    public partial class addusermodel200420200309am : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateofJoin",
                table: "userModels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofJoin",
                table: "userModels");
        }
    }
}
