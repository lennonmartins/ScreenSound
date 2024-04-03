using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularColunaArtistaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("Musicas", "Id", 2, "ArtistaId", 1);
            migrationBuilder.UpdateData("Musicas", "Id", 3, "ArtistaId", 1);
            migrationBuilder.UpdateData("Musicas", "Id", 4, "ArtistaId", 1);
            
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento", "ArtistaId" },
                new object[] { "Dear Rosemary", 2011, 2 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento", "ArtistaId" },
                new object[] { "Lobo", 2001, 3 });
            migrationBuilder.InsertData("Musicas", new string[] { "Nome", "AnoLancamento", "ArtistaId" },
                new object[] { "Não Chore Mais", 1979, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas WHERE ArtistaId = 4 ");
            migrationBuilder.Sql("DELETE FROM Musicas WHERE ArtistaId = 3 ");
            migrationBuilder.Sql("DELETE FROM Musicas WHERE ArtistaId = 2 ");
            
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = null WHERE MusicaId = 4");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = null WHERE MusicaId = 3");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = null WHERE MusicaId = 2");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = null WHERE MusicaId = 1");
        }
    }
}
