using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL : DAL<Artista>
{
   public ArtistaDAL(ScreenSoundContext soundContext):base(soundContext){ }
}