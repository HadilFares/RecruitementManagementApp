using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitementManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class removetablefromdbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidatOffres_TCandidat_IdCandidat",
                schema: "rectruitement",
                table: "candidatOffres");

            migrationBuilder.DropForeignKey(
                name: "FK_candidatOffres_TOffre_codeOffre",
                schema: "rectruitement",
                table: "candidatOffres");

            migrationBuilder.DropForeignKey(
                name: "FK_TOffre_TRh_nameRh",
                schema: "rectruitement",
                table: "TOffre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TRh",
                schema: "rectruitement",
                table: "TRh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TOffre",
                schema: "rectruitement",
                table: "TOffre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TCandidat",
                schema: "rectruitement",
                table: "TCandidat");

            migrationBuilder.RenameTable(
                name: "TRh",
                schema: "rectruitement",
                newName: "RHs",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "TOffre",
                schema: "rectruitement",
                newName: "Offres",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "TCandidat",
                schema: "rectruitement",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "RHs",
                schema: "rectruitement",
                newName: "TRh",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "Offres",
                schema: "rectruitement",
                newName: "TOffre",
                newSchema: "rectruitement");

            migrationBuilder.RenameTable(
                name: "Candidats",
                schema: "rectruitement",
                newName: "TCandidat",
                newSchema: "rectruitement");

            migrationBuilder.RenameIndex(
                name: "IX_Offres_nameRh",
                schema: "rectruitement",
                table: "TOffre",
                newName: "IX_TOffre_nameRh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TRh",
                schema: "rectruitement",
                table: "TRh",
                column: "IdRh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TOffre",
                schema: "rectruitement",
                table: "TOffre",
                column: "codeOffre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TCandidat",
                schema: "rectruitement",
                table: "TCandidat",
                column: "IdCandidat");

            migrationBuilder.AddForeignKey(
                name: "FK_candidatOffres_TCandidat_IdCandidat",
                schema: "rectruitement",
                table: "candidatOffres",
                column: "IdCandidat",
                principalSchema: "rectruitement",
                principalTable: "TCandidat",
                principalColumn: "IdCandidat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidatOffres_TOffre_codeOffre",
                schema: "rectruitement",
                table: "candidatOffres",
                column: "codeOffre",
                principalSchema: "rectruitement",
                principalTable: "TOffre",
                principalColumn: "codeOffre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TOffre_TRh_nameRh",
                schema: "rectruitement",
                table: "TOffre",
                column: "nameRh",
                principalSchema: "rectruitement",
                principalTable: "TRh",
                principalColumn: "IdRh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
