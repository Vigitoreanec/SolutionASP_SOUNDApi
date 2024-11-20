
using Beatify.DataBase.Data;
using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beatify.DataBase.Repositories;

public class GenreRepository(BeatifyDBContext beatifyDBContext) : IGenreRepository
{
    public async Task AddAsync(Genre genre)
    {
        await beatifyDBContext.AddAsync(genre);
        await beatifyDBContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsByIdAsync(int id) => 
        await beatifyDBContext.Genres.AnyAsync(genre => genre.Id == id);

    public async Task<bool> ExistsByTitleAsync(string title) => 
        await beatifyDBContext.Genres.AnyAsync(genre => genre.Title == title);

    public async Task<List<Genre>> GetAllAsync() =>
        await beatifyDBContext.Genres.ToListAsync();

    public async Task<Genre> GetByIdAsync(int id) =>
        await beatifyDBContext.Genres.SingleAsync(g => g.Id == id);

    public async Task RemoveAsync(int id)
    {
        await beatifyDBContext.Groups
            .Where(genre => genre.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(int id, Genre genre)
    {
        await beatifyDBContext.Genres
            .Where(genre => genre.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(g => g.Title, genre.Title)
                .SetProperty(g => g.Groups, genre.Groups)
            );
    }
}
