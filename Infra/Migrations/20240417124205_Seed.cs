using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingCompanies",
                columns: new[] { "TrainingCompanyID", "Address", "CompanyName", "EmailID", "MobileNo", "Password", "WebsiteUrl" },
                values: new object[] { 1L, "Akurdi Pune", "RI-TECH", "contact@ritehcpune.com", "978686787686", "abcd", "https://www.ritechpune.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingCompanies",
                keyColumn: "TrainingCompanyID",
                keyValue: 1L);
        }
    }
}
