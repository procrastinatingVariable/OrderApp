using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderApp.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuItemID",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MenuItemID",
                table: "Restaurant",
                column: "MenuItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_MenuItem_MenuItemID",
                table: "Restaurant",
                column: "MenuItemID",
                principalTable: "MenuItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_MenuItem_MenuItemID",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_MenuItemID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "MenuItemID",
                table: "Restaurant");
        }
    }
}
