using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitementManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class addtablefromdbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidatOffres_Candidats_IdCandidat",
                schema: "rectruitement",
                table: "candidatOffres");

            migrationBuilder.DropForeignKey(
                name: "FK_candidatOffres_Offres_codeOffre",
                schema: "rectruitement",
                table: "candidatOffres");

            migrationBuilder.DropForeignKey(
                name: "FK_Offres_RHs_nameRh",
                schema: "rectruitement",
                table: "Offres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RHs",
                schema: "rectruitement",
                table: "RHs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offres",
                schema: "rectruitement",
                table: "Offres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidats",
                schema: "rectruitement",
                table: "Candidats");

            migrationBuilder.EnsureSchema(
                name: "recruitement");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "rectruitement",
                newName: "Users",
                newSchema: "recruitement");

            migrationBuilder.RenameTable(
                name: "candidatOffres",
                schema: "rectruitement",
                newName: "candidatOffres",
                newSchema: "recruitement");

            migrationBuilder.RenameTable(
                name: "RHs",
                schema: "rectruitement",
                newName: "TRh",
                newSchema: "recruitement");

            migrationBuilder.RenameTable(
                name: "Offres",
                schema: "rectruitement",
                newName: "TOffre",
                newSchema: "recruitement");

            migrationBuilder.RenameTable(
                name: "Candidats",
                schema: "rectruitement",
                newName: "TCandidat",
                newSchema: "recruitement");

            migrationBuilder.RenameIndex(
                name: "IX_Offres_nameRh",
                schema: "recruitement",
                table: "TOffre",
                newName: "IX_TOffre_nameRh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TRh",
                schema: "recruitement",
                table: "TRh",
                column: "IdRh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TOffre",
                schema: "recruitement",
                table: "TOffre",
                column: "codeOffre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TCandidat",
                schema: "recruitement",
                table: "TCandidat",
                column: "IdCandidat");

            migrationBuilder.AddForeignKey(
                name: "FK_candidatOffres_TCandidat_IdCandidat",
                schema: "recruitement",
                table: "candidatOffres",
                column: "IdCandidat",
                principalSchema: "recruitement",
                principalTable: "TCandidat",
                principalColumn: "IdCandidat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidatOffres_TOffre_codeOffre",
                schema: "recruitement",
                table: "candidatOffres",
                column: "codeOffre",
                principalSchema: "recruitement",
                principalTable: "TOffre",
                principalColumn: "codeOffre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TOffre_TRh_nameRh",
                schema: "recruitement",
                table: "TOffre",
                column: "nameRh",
                principalSchema: "recruitement",
                principalTable: "TRh",
                principalColumn: "IdRh",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidatOffres_TCandidat_IdCandidat",
                schema: "recruitement",
                table: "candidatOffres");

            migrationBuilder.DropForeignKey(
                name: "FK_candidatOffres_TOffre_codeOffre",
                schema: "recruitement",
                table: "candidatOffres");

            migrationBuilder.DropForeignKey(
                name: "FK_TOffre_TRh_nameRh",
                schema: "recruitement",
                table: "TOffre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TRh",
                schema: "recruitement",
                table: "TRh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TOffre",
                schema: "recruitement",
                table: "TOffre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TCandidat",
                schema: "recruitement",
                table: "TCandidat");

            migrationBuilder.EnsureSchema(
                name: "rectruitement");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "recruitement",
                newName: "Users",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "candidatOffres",
                schema: "recruitement",
                newName: "candidatOffres",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "TRh",
                schema: "recruitement",
                newName: "RHs",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "TOffre",
                schema: "recruitement",
                newName: "Offres",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "TCandidat",
                schema: "recruitement",
                newName: "Candidats",
                newSchema: "rectruitement");

            migrationBuilder.RenameIndex(
                name: "IX_TOffre_nameRh",
                schema: "rectruitement",
                table: "Offres",
                newName: "IX_Offres_nameRh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RHs",
                schema: "rectruitement",
                table: "RHs",
                column: "IdRh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offres",
                schema: "rectruitement",
                table: "Offres",
                column: "codeOffre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidats",
                schema: "rectruitement",
                table: "Candidats",
                column: "IdCandidat");

            migrationBuilder.AddForeignKey(
                name: "FK_candidatOffres_Candidats_IdCandidat",
                schema: "rectruitement",
                table: "candidatOffres",
                column: "IdCandidat",
                principalSchema: "rectruitement",
                principalTable: "Candidats",
                principalColumn: "IdCandidat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidatOffres_Offres_codeOffre",
                schema: "rectruitement",
                table: "candidatOffres",
                column: "codeOffre",
                principalSchema: "rectruitement",
                principalTable: "Offres",
                principalColumn: "codeOffre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offres_RHs_nameRh",
                schema: "rectruitement",
                table: "Offres",
                column: "nameRh",
                principalSchema: "rectruitement",
                principalTable: "RHs",
                principalColumn: "IdRh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
