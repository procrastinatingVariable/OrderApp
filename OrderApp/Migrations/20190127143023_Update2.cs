using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderApp.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Restaurant_restaurantID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_MenuItem_MenuItemID",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_MenuItemID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "MenuItemID",
                table: "Restaurant");

            migrationBuilder.RenameColumn(
                name: "restaurantID",
                table: "Order",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_restaurantID",
                table: "Order",
                newName: "IX_Order_RestaurantID");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RestaurantID",
                table: "MenuItem",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Restaurant_RestaurantID",
                table: "MenuItem",
                column: "RestaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restaurant_RestaurantID",
                table: "Order",
                column: "RestaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Restaurant_RestaurantID",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Restaurant_RestaurantID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_RestaurantID",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "MenuItem");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Order",
                newName: "restaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_RestaurantID",
                table: "Order",
                newName: "IX_Order_restaurantID");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemID",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "restaurantID",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MenuItemID",
                table: "Restaurant",
                column: "MenuItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Restaurant_restaurantID",
                table: "Order",
                column: "restaurantID",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_MenuItem_MenuItemID",
                table: "Restaurant",
                column: "MenuItemID",
                principalTable: "MenuItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
