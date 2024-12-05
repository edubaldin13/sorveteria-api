using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorveteria.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
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
                    ValorBola = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Sabores_Sabor1Id",
                        column: x => x.Sabor1Id,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Sabores_Sabor2Id",
                        column: x => x.Sabor2Id,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sabores",
                columns: new[] { "Id", "Nome", "ValorBola" },
                values: new object[] { 1, "Mousse de Maracuja", 10.2m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nome", "Salt", "Senha" },
                values: new object[] { 1, "eduarbaldin@gmail.com", "Admin Eduardo", null, "123456" });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "Ativo", "NomeCliente", "QuantidadeBolas", "Sabor1Id", "Sabor2Id", "Valor" },
                values: new object[] { 1, true, "Eduardo", 1, 1, null, 10.2m });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Sabor1Id",
                table: "Pedidos",
                column: "Sabor1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Sabor2Id",
                table: "Pedidos",
                column: "Sabor2Id");

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
