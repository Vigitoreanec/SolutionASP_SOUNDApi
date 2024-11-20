using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeatifySOUND.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController(IAlbumRepository albumRepository) : ControllerBase
{
    [HttpGet(Name = "GetAllAlbums")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Album>))]

    public async Task<IActionResult> GetAlbums()
    {
        return Ok(await albumRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Album))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (!await albumRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        var album = await albumRepository.GetByIdAsync(id);
        return Ok(album);
        //return album == null ? Results.NotFound() : Results.Ok(album);
    }

    [HttpPost(Name = "AddAlbums")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    public async Task<IActionResult> AddAlbum(Album album)
    {
        if (album == null)
        {
            BadRequest();
        }
        if (await albumRepository.ExistsByTitleAsync(album.Title))
        {
            ModelState.AddModelError("", "Album already exists!");
            return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
        }
        await albumRepository.AddAsync(album);
        return Ok();
    }


    [HttpDelete(Name = "DeleteAlbum")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        if (!await albumRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        await albumRepository.RemoveAsync(id);
        return Ok();
    }


    [HttpPut(Name = "UpdateAlbum")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(int id, Album album)
    {
        if (!await albumRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        await albumRepository.UpdateAsync(id, album);
        return Ok();
    }
}
