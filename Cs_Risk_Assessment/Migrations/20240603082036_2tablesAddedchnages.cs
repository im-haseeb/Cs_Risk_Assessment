using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Risk_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class _2tablesAddedchnages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Assessments_AssessmentId",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "Threats",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_Threats_AssessmentId",
                table: "Threats",
                newName: "IX_Threats_AssetId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssessmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssessmentId",
                table: "Asset",
                column: "AssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Asset_AssetId",
                table: "Threats",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Asset_AssetId",
                table: "Threats");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Threats",
                newName: "AssessmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Threats_AssetId",
                table: "Threats",
                newName: "IX_Threats_AssessmentId");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Assessments_AssessmentId",
                table: "Threats",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "Id");
        }
    }
}
