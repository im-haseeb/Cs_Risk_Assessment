using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Risk_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class vulTableAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vulnerability_Threats_ThreatId",
                table: "Vulnerability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vulnerability",
                table: "Vulnerability");

            migrationBuilder.RenameTable(
                name: "Vulnerability",
                newName: "Vulnerabilities");

            migrationBuilder.RenameIndex(
                name: "IX_Vulnerability_ThreatId",
                table: "Vulnerabilities",
                newName: "IX_Vulnerabilities_ThreatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vulnerabilities",
                table: "Vulnerabilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vulnerabilities_Threats_ThreatId",
                table: "Vulnerabilities",
                column: "ThreatId",
                principalTable: "Threats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vulnerabilities_Threats_ThreatId",
                table: "Vulnerabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vulnerabilities",
                table: "Vulnerabilities");

            migrationBuilder.RenameTable(
                name: "Vulnerabilities",
                newName: "Vulnerability");

            migrationBuilder.RenameIndex(
                name: "IX_Vulnerabilities_ThreatId",
                table: "Vulnerability",
                newName: "IX_Vulnerability_ThreatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vulnerability",
                table: "Vulnerability",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vulnerability_Threats_ThreatId",
                table: "Vulnerability",
                column: "ThreatId",
                principalTable: "Threats",
                principalColumn: "Id");
        }
    }
}
