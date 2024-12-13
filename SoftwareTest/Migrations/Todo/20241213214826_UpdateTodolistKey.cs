using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareTest.Migrations.Todo
{
    /// <inheritdoc />
    public partial class UpdateTodolistKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Cpr",
            //     columns: table => new
            //     {
            //         CprNr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //         User = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Cpr", x => x.CprNr);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Todolist",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //         Item = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Todolist", x => x.UserId);
            //         table.ForeignKey(
            //             name: "FK_Todolist_Cpr",
            //             column: x => x.UserId,
            //             principalTable: "Cpr",
            //             principalColumn: "CprNr");
            //     });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todolist");

            migrationBuilder.DropTable(
                name: "Cpr");
        }
    }
}
