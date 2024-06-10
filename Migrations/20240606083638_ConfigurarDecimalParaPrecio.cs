using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAlvaro.Migrations
{
    public partial class ConfigurarDecimalParaPrecio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Marca = table.Column<string>(maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
