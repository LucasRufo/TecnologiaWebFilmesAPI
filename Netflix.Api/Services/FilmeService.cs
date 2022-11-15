using Netflix.Api.Models;

namespace Netflix.Api.Services;

public class FilmeService : IFilmeService
{
    private static int fakeId = 0;

    private List<Filme> _filmes = new List<Filme>();

    public bool AlterarFilme(Filme filme)
    {
        var indexFilme = _filmes.FindIndex(f => f.Id == filme.Id);

        if(indexFilme >= 0)
        {
            _filmes[indexFilme] = filme;
            return true;
        }

        return false;
    }

    public bool DeletarFilme(string id)
    {
        var indexFilme = _filmes.FindIndex(f => f.Id == id);

        if (indexFilme >= 0)
        {
            _filmes.RemoveAt(indexFilme);
            return true;
        }

        return false;
    }

    public List<Filme> ListarFilmes() => _filmes.Select(f => f).ToList();

    public Filme? ObterFilme(string id) => _filmes.FirstOrDefault(f => f.Id == id);

    public bool SalvarFilme(Filme filme)
    {
        if(filme != null)
        {
            filme.Id = fakeId++.ToString();
            _filmes.Add(filme);

            return true;
        }

        return false;
    }
}

