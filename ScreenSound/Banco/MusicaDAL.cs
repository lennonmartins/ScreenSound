using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class MusicaDAL: DAL<Musica>
{
    private readonly ScreenSoundContext _soundContext;

    public MusicaDAL(ScreenSoundContext soundContext)
    {
        _soundContext = soundContext;
    }

    public override IEnumerable<Musica> Listar()
    {
        return _soundContext.Musicas.ToList();
    }

    public override void Adicionar(Musica musica)
    {
        _soundContext.Musicas.Add(musica);
        _soundContext.SaveChanges();
    }

    public override void Atualizar(Musica musica)
    {
        _soundContext.Musicas.Update(musica);
        _soundContext.SaveChanges();
    }

    public override void Deletar(Musica musica)
    {
        var musicaRetoranda = _soundContext.Musicas.FirstOrDefault(ms => ms.Id == musica.Id);
        if (musicaRetoranda == null) throw new Exception("Música não encontrada!");
        _soundContext.Remove(musicaRetoranda);
        _soundContext.SaveChanges();
    }
}