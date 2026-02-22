using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkladProject.Migrations
{
    /// <inheritdoc />
    public partial class RenameFieldsToMatchDjango : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goodincomes_Goods_GoodsId",
                table: "Goodincomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodincomes_Stocks_StocksId",
                table: "Goodincomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodmoves_Goods_GoodsId",
                table: "Goodmoves");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodmoves_Stocks_StocksFromId",
                table: "Goodmoves");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodmoves_Stocks_StocksToId",
                table: "Goodmoves");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "Goodmoves",
                newName: "qty");

            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "Goodmoves",
                newName: "datetime");

            migrationBuilder.RenameColumn(
                name: "StocksToId",
                table: "Goodmoves",
                newName: "stockTo");

            migrationBuilder.RenameColumn(
                name: "StocksFromId",
                table: "Goodmoves",
                newName: "stockFrom");

            migrationBuilder.RenameColumn(
                name: "GoodsId",
                table: "Goodmoves",
                newName: "good");

            migrationBuilder.RenameIndex(
                name: "IX_Goodmoves_StocksToId",
                table: "Goodmoves",
                newName: "IX_Goodmoves_stockTo");

            migrationBuilder.RenameIndex(
                name: "IX_Goodmoves_StocksFromId",
                table: "Goodmoves",
                newName: "IX_Goodmoves_stockFrom");

            migrationBuilder.RenameIndex(
                name: "IX_Goodmoves_GoodsId",
                table: "Goodmoves",
                newName: "IX_Goodmoves_good");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "Goodincomes",
                newName: "qty");

            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "Goodincomes",
                newName: "datetime");

            migrationBuilder.RenameColumn(
                name: "StocksId",
                table: "Goodincomes",
                newName: "stock");

            migrationBuilder.RenameColumn(
                name: "GoodsId",
                table: "Goodincomes",
                newName: "good");

            migrationBuilder.RenameIndex(
                name: "IX_Goodincomes_StocksId",
                table: "Goodincomes",
                newName: "IX_Goodincomes_stock");

            migrationBuilder.RenameIndex(
                name: "IX_Goodincomes_GoodsId",
                table: "Goodincomes",
                newName: "IX_Goodincomes_good");

            migrationBuilder.AddForeignKey(
                name: "FK_Goodincomes_Goods_good",
                table: "Goodincomes",
                column: "good",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodincomes_Stocks_stock",
                table: "Goodincomes",
                column: "stock",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodmoves_Goods_good",
                table: "Goodmoves",
                column: "good",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodmoves_Stocks_stockFrom",
                table: "Goodmoves",
                column: "stockFrom",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodmoves_Stocks_stockTo",
                table: "Goodmoves",
                column: "stockTo",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goodincomes_Goods_good",
                table: "Goodincomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodincomes_Stocks_stock",
                table: "Goodincomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodmoves_Goods_good",
                table: "Goodmoves");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodmoves_Stocks_stockFrom",
                table: "Goodmoves");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodmoves_Stocks_stockTo",
                table: "Goodmoves");

            migrationBuilder.RenameColumn(
                name: "qty",
                table: "Goodmoves",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "Goodmoves",
                newName: "Datetime");

            migrationBuilder.RenameColumn(
                name: "stockTo",
                table: "Goodmoves",
                newName: "StocksToId");

            migrationBuilder.RenameColumn(
                name: "stockFrom",
                table: "Goodmoves",
                newName: "StocksFromId");

            migrationBuilder.RenameColumn(
                name: "good",
                table: "Goodmoves",
                newName: "GoodsId");

            migrationBuilder.RenameIndex(
                name: "IX_Goodmoves_stockTo",
                table: "Goodmoves",
                newName: "IX_Goodmoves_StocksToId");

            migrationBuilder.RenameIndex(
                name: "IX_Goodmoves_stockFrom",
                table: "Goodmoves",
                newName: "IX_Goodmoves_StocksFromId");

            migrationBuilder.RenameIndex(
                name: "IX_Goodmoves_good",
                table: "Goodmoves",
                newName: "IX_Goodmoves_GoodsId");

            migrationBuilder.RenameColumn(
                name: "qty",
                table: "Goodincomes",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "Goodincomes",
                newName: "Datetime");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "Goodincomes",
                newName: "StocksId");

            migrationBuilder.RenameColumn(
                name: "good",
                table: "Goodincomes",
                newName: "GoodsId");

            migrationBuilder.RenameIndex(
                name: "IX_Goodincomes_stock",
                table: "Goodincomes",
                newName: "IX_Goodincomes_StocksId");

            migrationBuilder.RenameIndex(
                name: "IX_Goodincomes_good",
                table: "Goodincomes",
                newName: "IX_Goodincomes_GoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goodincomes_Goods_GoodsId",
                table: "Goodincomes",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodincomes_Stocks_StocksId",
                table: "Goodincomes",
                column: "StocksId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodmoves_Goods_GoodsId",
                table: "Goodmoves",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodmoves_Stocks_StocksFromId",
                table: "Goodmoves",
                column: "StocksFromId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodmoves_Stocks_StocksToId",
                table: "Goodmoves",
                column: "StocksToId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
