using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotProducts.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Produtos");
        }
    }
}
