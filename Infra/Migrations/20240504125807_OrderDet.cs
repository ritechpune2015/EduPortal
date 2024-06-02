using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class OrderDet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDets_CourseTbl_CourseID",
                table: "OrderDets");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDets_OrderTbl_OrderID",
                table: "OrderDets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDets",
                table: "OrderDets");

            migrationBuilder.RenameTable(
                name: "OrderDets",
                newName: "OrderDetTbl");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDets_OrderID",
                table: "OrderDetTbl",
                newName: "IX_OrderDetTbl_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDets_CourseID",
                table: "OrderDetTbl",
                newName: "IX_OrderDetTbl_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetTbl",
                table: "OrderDetTbl",
                column: "OrderDetID");

            migrationBuilder.CreateTable(
                name: "OrderComplaintTbl",
                columns: table => new
                {
                    OrderComplaintID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    ComplaintTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComplaintTbl", x => x.OrderComplaintID);
                    table.ForeignKey(
                        name: "FK_OrderComplaintTbl_OrderTbl_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderTbl",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderComplaintSolutionTbl",
                columns: table => new
                {
                    OrderComplaintSolutionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderComplaintID = table.Column<long>(type: "bigint", nullable: false),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComplaintSolutionTbl", x => x.OrderComplaintSolutionID);
                    table.ForeignKey(
                        name: "FK_OrderComplaintSolutionTbl_OrderComplaintTbl_OrderComplaintID",
                        column: x => x.OrderComplaintID,
                        principalTable: "OrderComplaintTbl",
                        principalColumn: "OrderComplaintID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderComplaintSolutionTbl_OrderComplaintID",
                table: "OrderComplaintSolutionTbl",
                column: "OrderComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComplaintTbl_OrderID",
                table: "OrderComplaintTbl",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetTbl_CourseTbl_CourseID",
                table: "OrderDetTbl",
                column: "CourseID",
                principalTable: "CourseTbl",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetTbl_OrderTbl_OrderID",
                table: "OrderDetTbl",
                column: "OrderID",
                principalTable: "OrderTbl",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetTbl_CourseTbl_CourseID",
                table: "OrderDetTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetTbl_OrderTbl_OrderID",
                table: "OrderDetTbl");

            migrationBuilder.DropTable(
                name: "OrderComplaintSolutionTbl");

            migrationBuilder.DropTable(
                name: "OrderComplaintTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetTbl",
                table: "OrderDetTbl");

            migrationBuilder.RenameTable(
                name: "OrderDetTbl",
                newName: "OrderDets");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetTbl_OrderID",
                table: "OrderDets",
                newName: "IX_OrderDets_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetTbl_CourseID",
                table: "OrderDets",
                newName: "IX_OrderDets_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDets",
                table: "OrderDets",
                column: "OrderDetID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDets_CourseTbl_CourseID",
                table: "OrderDets",
                column: "CourseID",
                principalTable: "CourseTbl",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDets_OrderTbl_OrderID",
                table: "OrderDets",
                column: "OrderID",
                principalTable: "OrderTbl",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
