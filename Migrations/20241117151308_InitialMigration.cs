using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorveteria.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorBola = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeBolas = table.Column<int>(type: "int", nullable: false),
                    Sabor1Id = table.Column<int>(type: "int", nullable: false),
                    Sabor2Id = table.Column<int>(type: "int", nullable: true),
                    SaborId = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Sabores_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabores",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "NomeCliente", "QuantidadeBolas", "Sabor1Id", "Sabor2Id", "SaborId", "Valor" },
                values: new object[] { 1, "Mousse de Maracuja", 1, 1, null, null, 10.99m });

            migrationBuilder.InsertData(
                table: "Sabores",
                columns: new[] { "Id", "Nome", "ValorBola" },
                values: new object[] { 1, "Mousse de Maracuja", 10.99m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[] { 1, "eduarbaldin@gmail.com", "Admin Eduardo", "123456" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SaborId",
                table: "Pedidos",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sabores");
        }
    }
}
