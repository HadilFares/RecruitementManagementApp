using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitementManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class association : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rectruitement");

            migrationBuilder.CreateTable(
                name: "TCandidat",
                schema: "rectruitement",
                columns: table => new
                {
                    IdCandidat = table.Column<int>(type: "int", nullable: false),
              
                    DateNaiss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Langage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stagesexpercience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Githuburl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frameworks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCandidat", x => x.IdCandidat);
                });

            migrationBuilder.CreateTable(
                name: "TRh",
                schema: "rectruitement",
                columns: table => new
                {
                    IdRh = table.Column<int>(type: "int", nullable: false),
                    
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRh", x => x.IdRh);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "rectruitement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroUser = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profilecompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TOffre",
                schema: "rectruitement",
                columns: table => new
                {
                    codeOffre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameRh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOffre", x => x.codeOffre);
                    table.ForeignKey(
                        name: "FK_TOffre_TRh_nameRh",
                        column: x => x.nameRh,
                        principalSchema: "rectruitement",
                        principalTable: "TRh",
                        principalColumn: "IdRh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidatOffres",
                schema: "rectruitement",
                columns: table => new
                {
                    IdCandidat = table.Column<int>(type: "int", nullable: false),
                    codeOffre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidatOffres", x => new { x.IdCandidat, x.codeOffre });
                    table.ForeignKey(
                        name: "FK_candidatOffres_TCandidat_IdCandidat",
                        column: x => x.IdCandidat,
                        principalSchema: "rectruitement",
                        principalTable: "TCandidat",
                        principalColumn: "IdCandidat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidatOffres_TOffre_codeOffre",
                        column: x => x.codeOffre,
                        principalSchema: "rectruitement",
                        principalTable: "TOffre",
                        principalColumn: "codeOffre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidatOffres_codeOffre",
                schema: "rectruitement",
                table: "candidatOffres",
                column: "codeOffre");

            migrationBuilder.CreateIndex(
                name: "IX_TOffre_nameRh",
                schema: "rectruitement",
                table: "TOffre",
                column: "nameRh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidatOffres",
                schema: "rectruitement");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "rectruitement");

            migrationBuilder.DropTable(
                name: "TCandidat",
                schema: "rectruitement");

            migrationBuilder.DropTable(
                name: "TOffre",
                schema: "rectruitement");

            migrationBuilder.DropTable(
                name: "TRh",
                schema: "rectruitement");
        }
    }
}
