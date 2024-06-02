using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CourseChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TrainingCompanyID1",
                table: "TrainingCompanies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TrainingCompanyID",
                table: "CourseTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "TrainingCompanies",
                keyColumn: "TrainingCompanyID",
                keyValue: 1L,
                columns: new[] { "EmailID", "TrainingCompanyID1" },
                values: new object[] { "contact@ritechpune.com", null });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCompanies_TrainingCompanyID1",
                table: "TrainingCompanies",
                column: "TrainingCompanyID1");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTbl_TrainingCompanyID",
                table: "CourseTbl",
                column: "TrainingCompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTbl_TrainingCompanies_TrainingCompanyID",
                table: "CourseTbl",
                column: "TrainingCompanyID",
                principalTable: "TrainingCompanies",
                principalColumn: "TrainingCompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCompanies_TrainingCompanies_TrainingCompanyID1",
                table: "TrainingCompanies",
                column: "TrainingCompanyID1",
                principalTable: "TrainingCompanies",
                principalColumn: "TrainingCompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTbl_TrainingCompanies_TrainingCompanyID",
                table: "CourseTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCompanies_TrainingCompanies_TrainingCompanyID1",
                table: "TrainingCompanies");

            migrationBuilder.DropIndex(
                name: "IX_TrainingCompanies_TrainingCompanyID1",
                table: "TrainingCompanies");

            migrationBuilder.DropIndex(
                name: "IX_CourseTbl_TrainingCompanyID",
                table: "CourseTbl");

            migrationBuilder.DropColumn(
                name: "TrainingCompanyID1",
                table: "TrainingCompanies");

            migrationBuilder.DropColumn(
                name: "TrainingCompanyID",
                table: "CourseTbl");

            migrationBuilder.UpdateData(
                table: "TrainingCompanies",
                keyColumn: "TrainingCompanyID",
                keyValue: 1L,
                column: "EmailID",
                value: "contact@ritehcpune.com");
        }
    }
}
