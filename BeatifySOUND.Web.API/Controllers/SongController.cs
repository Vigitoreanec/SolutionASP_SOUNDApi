using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeatifySOUND.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController(ISongRepository songRepository) : ControllerBase
    {
        [HttpGet(Name = "GetAllSongs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Song>))]

        public async Task<IActionResult> GetSongs()
        {
            var song = await songRepository.GetAllAsync();
            return Ok(song);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Song))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!await songRepository.ExistsByIdAsync(id))
            {
                NotFound();
            }
            var song = await songRepository.GetByIdAsync(id);
            return Ok(song);
            //return proup == null ? Results.NotFound() : Results.Ok(song);
        }

        [HttpPost(Name = "AddSong")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
        public async Task<IActionResult> AddGroup([FromForm] Song song)
        {
            if (song == null)
            {
                BadRequest();
            }
            if (await songRepository.ExistsByTitleAsync(song.Title))
            {
                ModelState.AddModelError("", "Song already exists!");
                return StatusCode(StatusCodes.Status402PaymentRequired, ModelState);
            }
            await songRepository.AddAsync(song);
            return Ok();
        }


        [HttpDelete(Name = "DeleteSong")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            if (!await songRepository.ExistsByIdAsync(id))
            {
                NotFound();
            }
            await songRepository.RemoveAsync(id);
            return Ok();
        }


        [HttpPut(Name = "UpdateSong")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Song song)
        {
            if (!await songRepository.ExistsByIdAsync(id))
            {
                NotFound();
            }
            await songRepository.UpdateAsync(id, song);
            return Ok();
        }
    }
}
