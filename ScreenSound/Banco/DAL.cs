using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class DAL<T> where T : class
{
    protected readonly ScreenSoundContext _soundContext;

    public DAL(ScreenSoundContext soundContext)
    {
        _soundContext = soundContext;
    }

    public IEnumerable<T> Listar()
    {
        return _soundContext.Set<T>().ToList();
    }

    public void Adicionar(T objeto)
    {
        _soundContext.Set<T>().Add(objeto);
        _soundContext.SaveChanges();
    }

    public void Atualizar(T objeto)
    {
        _soundContext.Set<T>().Update(objeto);
        _soundContext.SaveChanges();
    }

    public void Deletar(T objeto)
    {
        var artistaADeletar = _soundContext.Set<T>().AsEnumerable().FirstOrDefault(objeto);
        if (artistaADeletar == null) throw new Exception($" {objeto} não encontrado(a)!");
        _soundContext.Remove(artistaADeletar);
        _soundContext.SaveChanges();
    }
    
    public T? RecuperarPelo(Func<T,bool> condicao)
    {
        var objetoRetornado = _soundContext.Set<T>().FirstOrDefault(condicao);
        if (objetoRetornado == null) throw new Exception($"{condicao} não encontrado(a)!");
        return objetoRetornado;
    }

    public IEnumerable<T>? ListarPor(Func<T,bool> condicao)
    {
        var listaRetornada = _soundContext.Set<T>().Where(condicao);
        return listaRetornada;
    }
}