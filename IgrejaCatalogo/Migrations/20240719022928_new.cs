using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IgrejaCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias (CategoriaName) VALUES ('Patrimonio historico')");

            mb.Sql("INSERT INTO Categorias (CategoriaName) VALUES ('Não patrimonio historico')");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categoria");
        }
    }
}
