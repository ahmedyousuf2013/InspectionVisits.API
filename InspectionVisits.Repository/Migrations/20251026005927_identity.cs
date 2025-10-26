using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionVisits.Repository.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Violations_InspectionVisitId",
                table: "Violations",
                column: "InspectionVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_InspectionVisits_InspectionVisitId",
                table: "Violations",
                column: "InspectionVisitId",
                principalTable: "InspectionVisits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_InspectionVisits_InspectionVisitId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_InspectionVisitId",
                table: "Violations");
        }
    }
}
