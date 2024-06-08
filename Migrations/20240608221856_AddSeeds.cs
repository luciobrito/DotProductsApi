using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotProducts.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Role", "Senha" },
                values: new object[] { 1, "admin@email.com", "Admin", "Admin", "$2a$12$xgKYROqH9MPTbrCgPfbQ7.i6FvZBWMKGvoRUPkAD2wipR50X3jm5q" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
