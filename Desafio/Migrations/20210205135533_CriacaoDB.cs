using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Migrations
{
    public partial class CriacaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    ValorUnitario = table.Column<double>(type: "float", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(70)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItensId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Item_ItensId",
                        column: x => x.ItensId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Codigo", "Desconto", "Quantidade", "ValorTotal", "ValorUnitario" },
                values: new object[] { 1, "AB1", 0.0, 1.0, 1.5, 1.5 });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Codigo", "Desconto", "Quantidade", "ValorTotal", "ValorUnitario" },
                values: new object[] { 2, "AB2", 0.10000000000000001, 2.0, 20.0, 10.0 });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Codigo", "Desconto", "Quantidade", "ValorTotal", "ValorUnitario" },
                values: new object[] { 3, "XY5", 0.050000000000000003, 5.0, 37.5, 7.5 });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ItensId",
                table: "Pedido",
                column: "ItensId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
