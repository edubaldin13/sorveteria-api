using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorveteria.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Valor",
                value: 10.2m);

            migrationBuilder.UpdateData(
                table: "Sabores",
                keyColumn: "Id",
                keyValue: 1,
                column: "ValorBola",
                value: 10.2m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Valor",
                value: 10.99m);

            migrationBuilder.UpdateData(
                table: "Sabores",
                keyColumn: "Id",
                keyValue: 1,
                column: "ValorBola",
                value: 10.99m);
        }
    }
}
