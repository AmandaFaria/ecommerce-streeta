using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Streeta.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Porcentagem = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Senha = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    Cep = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cupomId = table.Column<int>(type: "integer", nullable: true),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    ValorFinal = table.Column<double>(type: "double precision", nullable: false),
                    usuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Cupom_cupomId",
                        column: x => x.cupomId,
                        principalTable: "Cupom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compra_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vestuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Cor = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Tamanho = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Imagem = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    categoriaId = table.Column<int>(type: "integer", nullable: false),
                    CarrinhoId = table.Column<int>(type: "integer", nullable: true),
                    CompraId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vestuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vestuarios_Carrinho_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinho",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vestuarios_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vestuarios_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_cupomId",
                table: "Compra",
                column: "cupomId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_usuarioId",
                table: "Compra",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vestuarios_CarrinhoId",
                table: "Vestuarios",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vestuarios_categoriaId",
                table: "Vestuarios",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vestuarios_CompraId",
                table: "Vestuarios",
                column: "CompraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vestuarios");

            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
