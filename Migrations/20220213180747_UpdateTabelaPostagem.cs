using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditaNelas.Migrations
{
    public partial class UpdateTabelaPostagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Postagem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Postagem");
        }
    }
}
