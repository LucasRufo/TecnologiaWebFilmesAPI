using Netflix.Api.Models;

namespace Netflix.Api.Services;

public interface IFilmeService
{
    public List<Filme> ListarFilmes();
    public Filme? ObterFilme(string id);
    public bool SalvarFilme(Filme filme);
    public bool AlterarFilme(Filme filme);
    public bool DeletarFilme(string id);
}

