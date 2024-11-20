using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace BeatifySOUND.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController(IGroupRepository groupRepository) : ControllerBase
{
    //public List<string> Songs { get; set; } =
    //    [
    //        "1.Ludwig van Beethoven - Симфония № 9, Op. 125, Хорал",
    //        "2.Johann Sebastian Bach - Месса си минор",
    //        "3.Wolfgang Amadeus Mozart - Симфония № 41,  Юпитер",
    //        "4.Frederic Chopin - Ноктюрн № 2",
    //        "5.George Gershwin - Rhapsody in Blue",
    //        "6.Pyotr Ilyich Tchaikovsky - Симфония № 5",
    //        "7.Antonio Vivaldi - Четыре сезона",
    //        "8.Igor Stravinsky - Весна священная",
    //        "9.Giuseppe Verdi - Опера Травиата",
    //        "10.Richard Wagner - Опера Тристан и Изольда"
    //    ];

    //[HttpGet(Name = "GetListSongs")]
    //public IEnumerable<string> Get()
    //{
    //   return Songs;
    //}

    [HttpGet(Name = "GetAllGroups")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Group>))]
    
    public async Task<IActionResult> GetGroups()
    {
        return Ok(await groupRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Group))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if(!await groupRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        var group = await groupRepository.GetByIdAsync(id);
        return Ok(group);
        //return proup == null ? Results.NotFound() : Results.Ok(proup);
    }

    [HttpPost(Name = "AddGroup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    public async Task<IActionResult> AddGroup(Group group)
    {
        if (group == null)
        {
            BadRequest();
        }
        if(await groupRepository.ExistsByTitleAsync(group.Title))
        { 
            ModelState.AddModelError("", "Group already exists!");
            return StatusCode(StatusCodes.Status402PaymentRequired,ModelState);
        }
        await groupRepository.AddAsync(group);
        return Ok();
    }


    [HttpDelete(Name = "DeleteGroup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        if (!await groupRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        await groupRepository.RemoveAsync(id);
        return Ok();
    }


    [HttpPut(Name = "UpdateGroup")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(int id,Group group)
    {
        if (!await groupRepository.ExistsByIdAsync(id))
        {
            NotFound();
        }
        await groupRepository.UpdateAsync(id, group);
        return Ok();
    }
}
