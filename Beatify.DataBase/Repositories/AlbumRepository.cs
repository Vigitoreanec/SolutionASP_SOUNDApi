using Beatify.DataBase.Data;
using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beatify.DataBase.Repositories;

public class AlbumRepository(BeatifyDBContext beatifyDBContext) : IAlbumRepository
{
    public async Task AddAsync(Album album)
    {
        await beatifyDBContext.Albums.AddAsync(album);
        await beatifyDBContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsByIdAsync(int id) =>
        await beatifyDBContext.Albums.AnyAsync(album => album.Id == id);

    public async Task<bool> ExistsByTitleAsync(string title) =>
        await beatifyDBContext.Albums.AnyAsync(album => album.Title == title);

    public async Task<List<Album>> GetAllAsync() =>
        await beatifyDBContext.Albums.ToListAsync();

    public async Task<Album> GetByIdAsync(int id) =>
        await beatifyDBContext.Albums.SingleAsync(album => album.Id == id);

    public async Task RemoveAsync(int id)
    {
        await beatifyDBContext.Albums
            .Where(album => album.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(int id, Album album)
    {
        await beatifyDBContext.Albums
           .Where(a => a.Id == id)
           .ExecuteUpdateAsync(s => s
               .SetProperty(a => a.Title, album.Title)
               .SetProperty(a => a.Description, album.Description)
               .SetProperty(a => a.ReleaseDate, album.ReleaseDate)
               .SetProperty(a => a.Groups, album.Groups)
               .SetProperty(a => a.Songs, album.Songs)
           );
    }
}
