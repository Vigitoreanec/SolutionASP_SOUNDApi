using Beatify.DataBase.Entities;

namespace Beatify.DataBase.Repositories.Interfaces;

public interface ISongRepository
{
    Task AddAsync(Song song);
    Task<List<Song>> GetAllAsync();
    Task<Song> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(int id, Song song);
    Task<bool> ExistsByIdAsync(int id);
    Task<bool> ExistsByTitleAsync(string title);
}