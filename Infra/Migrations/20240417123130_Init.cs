using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubjectStreamTbl",
                columns: table => new
                {
                    SubjectStreamID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectStreamTbl", x => x.SubjectStreamID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCompanies",
                columns: table => new
                {
                    TrainingCompanyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCompanies", x => x.TrainingCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "UserTbl",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbl", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "SubjecTbl",
                columns: table => new
                {
                    SubjectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectStreamID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjecTbl", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_SubjecTbl_SubjectStreamTbl_SubjectStreamID",
                        column: x => x.SubjectStreamID,
                        principalTable: "SubjectStreamTbl",
                        principalColumn: "SubjectStreamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTbl",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTbl", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_OrderTbl_UserTbl_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTbl",
                columns: table => new
                {
                    CourseID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectID = table.Column<long>(type: "bigint", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInHours = table.Column<int>(type: "int", nullable: false),
                    Prerequisite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benifits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTbl", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_CourseTbl_SubjecTbl_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SubjecTbl",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDets",
                columns: table => new
                {
                    OrderDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDets", x => x.OrderDetID);
                    table.ForeignKey(
                        name: "FK_OrderDets_CourseTbl_CourseID",
                        column: x => x.CourseID,
                        principalTable: "CourseTbl",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDets_OrderTbl_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderTbl",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTbl_SubjectID",
                table: "CourseTbl",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDets_CourseID",
                table: "OrderDets",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDets_OrderID",
                table: "OrderDets",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTbl_UserID",
                table: "OrderTbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjecTbl_SubjectStreamID",
                table: "SubjecTbl",
                column: "SubjectStreamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDets");

            migrationBuilder.DropTable(
                name: "TrainingCompanies");

            migrationBuilder.DropTable(
                name: "CourseTbl");

            migrationBuilder.DropTable(
                name: "OrderTbl");

            migrationBuilder.DropTable(
                name: "SubjecTbl");

            migrationBuilder.DropTable(
                name: "UserTbl");

            migrationBuilder.DropTable(
                name: "SubjectStreamTbl");
        }
    }
}
