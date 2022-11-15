using Microsoft.AspNetCore.Mvc;
using Netflix.Api.Models;
using Netflix.Api.Services;

namespace Netflix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeApi : ControllerBase
{
    private readonly IFilmeService _filmeService;

    public FilmeApi(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(_filmeService.ListarFilmes());
    }

    [HttpGet("{id}")]
    public IActionResult GetMovies(string id)
    {
        var movie = _filmeService.ObterFilme(id);

        if (movie is null)
            return NotFound("Filme não encontrado!");

        return Ok(movie);
    }

    [HttpPost]
    public IActionResult CreateMovie(Filme movie)
    {
        var success = _filmeService.SalvarFilme(movie);

        if (!success)
            return BadRequest("Filme Inválido!");

        return Ok(movie);
    }

    [HttpPut]
    public IActionResult UpdateMovie(Filme movie)
    {
        var success = _filmeService.AlterarFilme(movie);

        if (!success)
            return NotFound("Filme não encontrado!");

        return Ok(movie);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(string id)
    {
        var success = _filmeService.DeletarFilme(id);

        if (!success)
            return NotFound("Filme não encontrado!");

        return Ok(id);
    }
}

