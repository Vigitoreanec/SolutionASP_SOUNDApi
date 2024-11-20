using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeatifySOUND.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController(IGenreRepository genreRepository) : ControllerBase
{
    [HttpGet(Name = "GetAllGenres")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Genre>))]

    public async Task<IActionResult> GetGenres()
    {
        var genre = await genreRepository.GetAllAsync();
        return Ok(genre);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Genre))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (!await genreRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        var genre = await genreRepository.GetByIdAsync(id);
        return Ok(genre);
        //return genre == null ? Results.NotFound() : Results.Ok(genre);
    }

    [HttpPost(Name = "AddGenre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    public async Task<IActionResult> AddGenre(Genre genre)
    {
        if (genre == null)
        {
            BadRequest();
        }
        if (await genreRepository.ExistsByTitleAsync(genre.Title))
        {
            ModelState.AddModelError("", "Genre already exists!");
            return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
        }
        await genreRepository.AddAsync(genre);
        return Ok();
    }


    [HttpDelete(Name = "DeleteGenre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        if (!await genreRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        await genreRepository.RemoveAsync(id);
        return Ok();
    }


    [HttpPut(Name = "UpdateGenre")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(int id, Genre genre)
    {
        if (!await genreRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        await genreRepository.UpdateAsync(id, genre);
        return Ok();
    }
}
