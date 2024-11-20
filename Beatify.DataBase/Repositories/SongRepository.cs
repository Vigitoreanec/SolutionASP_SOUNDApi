using Beatify.DataBase.Data;
using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beatify.DataBase.Repositories;

public class SongRepository(BeatifyDBContext beatifyDBContext) : ISongRepository
{
    public async Task AddAsync(Song song)
    {
        await beatifyDBContext.AddAsync(song);
        await beatifyDBContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsByIdAsync(int id) => 
        await beatifyDBContext.Songs.AnyAsync(song => song.Id == id);

    public async Task<bool> ExistsByTitleAsync(string title) =>
        await beatifyDBContext.Songs.AnyAsync(song => song.Title == title);

    public async Task<List<Song>> GetAllAsync() =>
        await beatifyDBContext.Songs.ToListAsync();

    public async Task<Song> GetByIdAsync(int id) =>
        await beatifyDBContext.Songs.SingleAsync(song => song.Id == id);

    public async Task RemoveAsync(int id)
    {
        await beatifyDBContext.Songs
            .Where(song => song.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(int id, Song song)
    {
        await beatifyDBContext.Songs
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(x => x.Title, song.Title)
            .SetProperty(x => x.Description, song.Description)
            .SetProperty(x => x.Albums, song.Albums)
            );
    }

}
