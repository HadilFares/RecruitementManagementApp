using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitementManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class updateoffreandcandidatoffre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Questions",
                schema: "recruitement",
                table: "TOffre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNaiss",
                schema: "recruitement",
                table: "TCandidat",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "QuestionsResponse",
                schema: "recruitement",
                table: "candidatOffres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "recruitement",
                table: "candidatOffres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Questions",
                schema: "recruitement",
                table: "TOffre");

            migrationBuilder.DropColumn(
                name: "QuestionsResponse",
                schema: "recruitement",
                table: "candidatOffres");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "recruitement",
                table: "candidatOffres");

            migrationBuilder.AlterColumn<string>(
                name: "DateNaiss",
                schema: "recruitement",
                table: "TCandidat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
