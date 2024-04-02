using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabelaMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musica", new string[] { "Nome", "AnoLancamento" },
                new object[]
                {
                    "Oceano",
                    1989
                });
            migrationBuilder.InsertData("Musica", new string[] { "Nome", "AnoLancamento" },
                new object[]
                {
                    "Dear Rosemary",
                    2011
                });
            migrationBuilder.InsertData("Musica", new string[]
                {
                    "Nome", "AnoLancamento"
                },
                new object[]
                {
                    "Lobo",
                    2003
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
