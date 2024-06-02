using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Coursechanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benifits",
                table: "CourseTbl");

            migrationBuilder.RenameColumn(
                name: "CouseName",
                table: "CourseTbl",
                newName: "CourseName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "CourseTbl",
                newName: "CouseName");

            migrationBuilder.AddColumn<string>(
                name: "Benifits",
                table: "CourseTbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
