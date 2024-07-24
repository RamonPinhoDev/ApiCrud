using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IgrejaCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoiaId);
                });

            migrationBuilder.CreateTable(
                name: "Igrejas",
                columns: table => new
                {
                    IgrejaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    DateFundacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParocoResponsavel = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Diocese = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoiaId = table.Column<int>(type: "int", nullable: false),
                    CodCategoriaCategoiaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrejas", x => x.IgrejaId);
                    table.ForeignKey(
                        name: "FK_Igrejas_Categorias_CodCategoriaCategoiaId",
                        column: x => x.CodCategoriaCategoiaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoiaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igrejas_CodCategoriaCategoiaId",
                table: "Igrejas",
                column: "CodCategoriaCategoiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Igrejas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
