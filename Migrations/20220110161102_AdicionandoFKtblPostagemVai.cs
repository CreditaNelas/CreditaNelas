using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditaNelas.Migrations
{
    public partial class AdicionandoFKtblPostagemVai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postagens",
                columns: table => new
                {
                    Id_Postagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Whatsapp = table.Column<string>(nullable: false),
                    Id_Usuario = table.Column<int>(nullable: false),
                    UsuarioId_Usuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagens", x => x.Id_Postagem);
                    table.ForeignKey(
                        name: "FK_Postagens_Usuarios_UsuarioId_Usuario",
                        column: x => x.UsuarioId_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postagens_UsuarioId_Usuario",
                table: "Postagens",
                column: "UsuarioId_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postagens");
        }
    }
}
