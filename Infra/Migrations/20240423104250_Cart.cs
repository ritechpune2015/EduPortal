using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTbl_TrainingCompanies_TrainingCompanyID",
                table: "CourseTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCompanies_TrainingCompanies_TrainingCompanyID1",
                table: "TrainingCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingCompanies",
                table: "TrainingCompanies");

            migrationBuilder.RenameTable(
                name: "TrainingCompanies",
                newName: "TrainingCompanyTbl");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCompanies_TrainingCompanyID1",
                table: "TrainingCompanyTbl",
                newName: "IX_TrainingCompanyTbl_TrainingCompanyID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingCompanyTbl",
                table: "TrainingCompanyTbl",
                column: "TrainingCompanyID");

            migrationBuilder.CreateTable(
                name: "CartTbl",
                columns: table => new
                {
                    CartID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTbl", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_CartTbl_CourseTbl_CourseID",
                        column: x => x.CourseID,
                        principalTable: "CourseTbl",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartTbl_UserTbl_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartTbl_CourseID",
                table: "CartTbl",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CartTbl_UserID",
                table: "CartTbl",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTbl_TrainingCompanyTbl_TrainingCompanyID",
                table: "CourseTbl",
                column: "TrainingCompanyID",
                principalTable: "TrainingCompanyTbl",
                principalColumn: "TrainingCompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCompanyTbl_TrainingCompanyTbl_TrainingCompanyID1",
                table: "TrainingCompanyTbl",
                column: "TrainingCompanyID1",
                principalTable: "TrainingCompanyTbl",
                principalColumn: "TrainingCompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTbl_TrainingCompanyTbl_TrainingCompanyID",
                table: "CourseTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCompanyTbl_TrainingCompanyTbl_TrainingCompanyID1",
                table: "TrainingCompanyTbl");

            migrationBuilder.DropTable(
                name: "CartTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingCompanyTbl",
                table: "TrainingCompanyTbl");

            migrationBuilder.RenameTable(
                name: "TrainingCompanyTbl",
                newName: "TrainingCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCompanyTbl_TrainingCompanyID1",
                table: "TrainingCompanies",
                newName: "IX_TrainingCompanies_TrainingCompanyID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingCompanies",
                table: "TrainingCompanies",
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
    }
}
