using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitementManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class removequestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Questions",
                schema: "recruitement",
                table: "TOffre");

            migrationBuilder.DropColumn(
                name: "QuestionsResponse",
                schema: "recruitement",
                table: "candidatOffres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Questions",
                schema: "recruitement",
                table: "TOffre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionsResponse",
                schema: "recruitement",
                table: "candidatOffres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
