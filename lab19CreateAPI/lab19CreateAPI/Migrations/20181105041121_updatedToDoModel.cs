using Microsoft.EntityFrameworkCore.Migrations;

namespace lab19CreateAPI.Migrations
{
    public partial class updatedToDoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Lists_ListID",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ListID",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "ListID",
                table: "Todos");

            migrationBuilder.AddColumn<int>(
                name: "ToDoListID",
                table: "Todos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ToDoListID",
                table: "Todos",
                column: "ToDoListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Lists_ToDoListID",
                table: "Todos",
                column: "ToDoListID",
                principalTable: "Lists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Lists_ToDoListID",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ToDoListID",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "ToDoListID",
                table: "Todos");

            migrationBuilder.AddColumn<int>(
                name: "ListID",
                table: "Todos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ListID",
                table: "Todos",
                column: "ListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Lists_ListID",
                table: "Todos",
                column: "ListID",
                principalTable: "Lists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
