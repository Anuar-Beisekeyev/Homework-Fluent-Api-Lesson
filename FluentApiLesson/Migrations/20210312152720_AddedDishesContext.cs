using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentApiLesson.Migrations
{
    public partial class AddedDishesContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_dishes_dishId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_dishId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "dishId",
                table: "products");

            migrationBuilder.CreateTable(
                name: "ProductDishes",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDishes", x => new { x.ProductId, x.DishId });
                    table.ForeignKey(
                        name: "FK_ProductDishes_dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDishes_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDishes_DishId",
                table: "ProductDishes",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDishes");

            migrationBuilder.AddColumn<Guid>(
                name: "dishId",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_products_dishId",
                table: "products",
                column: "dishId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_dishes_dishId",
                table: "products",
                column: "dishId",
                principalTable: "dishes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
