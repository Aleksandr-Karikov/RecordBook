using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordBook.Migrations
{
    public partial class changeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Marks");

            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "Recordbooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "mark",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Recordbooks");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "Marks");

            migrationBuilder.AlterColumn<byte>(
                name: "mark",
                table: "Marks",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Semester",
                table: "Marks",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
