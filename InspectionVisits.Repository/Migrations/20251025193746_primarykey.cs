using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InspectionVisits.Repository.Migrations
{
    /// <inheritdoc />
    public partial class primarykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inspectors",
                columns: new[] { "Id", "Email", "FullName", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "Inspetor1@gamil.com", "Inspector 1", "01099999999", "admin" },
                    { 2, "Inspetor2@gamil.com", "Inspector 2", "01099999999", "inspector" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inspectors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inspectors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
