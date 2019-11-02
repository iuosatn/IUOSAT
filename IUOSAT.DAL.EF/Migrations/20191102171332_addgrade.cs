﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace IUOSAT.DAL.EF.Migrations
{
    public partial class addgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Grades",
                newName: "PersianName");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Grades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "PersianName",
                table: "Grades",
                newName: "Name");
        }
    }
}
