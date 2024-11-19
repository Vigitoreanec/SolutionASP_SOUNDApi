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
    public async Task<IEnumerable<Group>> GetGroups() => await groupRepository.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<Group> GetByIdAsync(int id)
    {
        var group = await groupRepository.GetByIdAsync(id);
        //return proup == null ? Results.NotFound() : Results.Ok(proup);
        return group;
    }

    [HttpPost(Name = "AddGroup")]
    public async Task AddGroup(Group group)
    {
        await groupRepository.AddAsync(group);
        
    }

    [HttpDelete(Name = "DeleteGroup")]
    public async Task RemoveAsync(int id)
    {
        await groupRepository.RemoveAsync(id);

    }
    [HttpPut(Name = "UpdateGroup")]
    public async Task UpdateAsync(int id,Group group)
    {
        await groupRepository.UpdateAsync(id, group);

    }
}
