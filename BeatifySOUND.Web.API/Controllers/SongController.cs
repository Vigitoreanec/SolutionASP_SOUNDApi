using Microsoft.AspNetCore.Mvc;

namespace BeatifySOUND.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    public List<string> Songs { get; set; } =
        [
            "Ludwig van Beethoven - Симфония № 9, Op. 125, Хорал",
            "Johann Sebastian Bach - Месса си минор",
            "Wolfgang Amadeus Mozart - Симфония № 41,  Юпитер",
            "Frederic Chopin - Ноктюрн № 2",
            "George Gershwin - Rhapsody in Blue",
            "Pyotr Ilyich Tchaikovsky - Симфония № 5",
            "Antonio Vivaldi - Четыре сезона",
            "Igor Stravinsky - Весна священная",
            "Giuseppe Verdi - Опера Травиата",
            "Richard Wagner - Опера Тристан и Изольда"
        ];

    [HttpGet(Name = "GetListSongs")]
    public IEnumerable<string> Get()
    {
       return Songs;
    }
}
