using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Risk_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class vulTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vulnerabilities",
                table: "Threats");

            migrationBuilder.CreateTable(
                name: "Vulnerability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeliHood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Impact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vulnerability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vulnerability_Threats_ThreatId",
                        column: x => x.ThreatId,
                        principalTable: "Threats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerability_ThreatId",
                table: "Vulnerability",
                column: "ThreatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vulnerability");

            migrationBuilder.AddColumn<string>(
                name: "Vulnerabilities",
                table: "Threats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
