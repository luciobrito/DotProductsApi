using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotProducts.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoAndViewRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "produto_Views",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Produtos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_produto_Views_ProdutoId",
                table: "produto_Views",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_Views_Produtos_ProdutoId",
                table: "produto_Views",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_Views_Produtos_ProdutoId",
                table: "produto_Views");

            migrationBuilder.DropIndex(
                name: "IX_produto_Views_ProdutoId",
                table: "produto_Views");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "produto_Views");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
