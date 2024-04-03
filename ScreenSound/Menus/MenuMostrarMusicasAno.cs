using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasAno : Menu
{
    public override void Executar(DAL<Artista> artistaDal)
    {
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Exibir musicas por ano");
        Console.WriteLine("Digite o ano de lançamento:");
        string anoDeLancamento = Console.ReadLine()!;
        var musicaDal = new DAL<Musica>(new ScreenSoundContext());
        var musicas = musicaDal.ListarPor(m => m.AnoLancamento == Convert.ToInt32(anoDeLancamento));
        if (musicas.Any())
        {
            foreach (var musica in musicas)
            {
                musica.ExibirFichaTecnica();
            }
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}