using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Risk_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class _2tablesAddedchnages2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Assessments_AssessmentId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Asset_AssetId",
                table: "Threats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_AssessmentId",
                table: "Assets",
                newName: "IX_Assets_AssessmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Assessments_AssessmentId",
                table: "Assets",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Assets_AssetId",
                table: "Threats",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Assessments_AssessmentId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Assets_AssetId",
                table: "Threats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Asset");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AssessmentId",
                table: "Asset",
                newName: "IX_Asset_AssessmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Assessments_AssessmentId",
                table: "Asset",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Asset_AssetId",
                table: "Threats",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id");
        }
    }
}
