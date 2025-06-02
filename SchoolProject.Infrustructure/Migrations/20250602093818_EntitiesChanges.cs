using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DName",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "subjects",
                newName: "SubjectNameAr");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "students",
                newName: "NameAr");

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameEn",
                table: "subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNameAr",
                table: "departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNameEn",
                table: "departments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectNameEn",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DNameAr",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DNameEn",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "SubjectNameAr",
                table: "subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "students",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "DName",
                table: "departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
