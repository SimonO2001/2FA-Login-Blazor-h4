using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareTest.Migrations.Todo
{
    /// <inheritdoc />
    public partial class AddIdToTodolist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Todolist",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Todolist");
        }
    }
}
