using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Restaurants_RestaurantId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_deliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersContains_Foods_foodId",
                table: "OrdersContains");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersContains_Orders_orderId",
                table: "OrdersContains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersContains",
                table: "OrdersContains");

            migrationBuilder.DropIndex(
                name: "IX_OrdersContains_foodId",
                table: "OrdersContains");

            migrationBuilder.DropIndex(
                name: "IX_Orders_deliveryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrdersContains");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "OrdersContains",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "foodId",
                table: "OrdersContains",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersContains_orderId",
                table: "OrdersContains",
                newName: "IX_OrdersContains_OrderId");

            migrationBuilder.RenameColumn(
                name: "deliveryId",
                table: "Orders",
                newName: "DeliveryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersContains",
                table: "OrdersContains",
                columns: new[] { "FoodId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Restaurants_RestaurantId",
                table: "Foods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersContains_Foods_FoodId",
                table: "OrdersContains",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersContains_Orders_OrderId",
                table: "OrdersContains",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Restaurants_RestaurantId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_DeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersContains_Foods_FoodId",
                table: "OrdersContains");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersContains_Orders_OrderId",
                table: "OrdersContains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersContains",
                table: "OrdersContains");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrdersContains",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "OrdersContains",
                newName: "foodId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersContains_OrderId",
                table: "OrdersContains",
                newName: "IX_OrdersContains_orderId");

            migrationBuilder.RenameColumn(
                name: "DeliveryId",
                table: "Orders",
                newName: "deliveryId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrdersContains",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersContains",
                table: "OrdersContains",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersContains_foodId",
                table: "OrdersContains",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_deliveryId",
                table: "Orders",
                column: "deliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Restaurants_RestaurantId",
                table: "Foods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_deliveryId",
                table: "Orders",
                column: "deliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersContains_Foods_foodId",
                table: "OrdersContains",
                column: "foodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersContains_Orders_orderId",
                table: "OrdersContains",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
