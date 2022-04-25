using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Edad = table.Column<long>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Sexo = table.Column<bool>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false),
                    Estatura = table.Column<long>(nullable: false),
                    Fumador = table.Column<bool>(nullable: false),
                    Dieta = table.Column<bool>(nullable: false),
                    PesoEstatura = table.Column<long>(nullable: false),
                    Prioridad = table.Column<double>(nullable: false),
                    Riesgo = table.Column<double>(nullable: false),
                    TiempoFumando = table.Column<long>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
