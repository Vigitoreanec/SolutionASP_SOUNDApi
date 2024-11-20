using Beatify.DataBase.Entities;

namespace Beatify.DataBase.Repositories.Interfaces;

public interface IAlbumRepository
{
    Task AddAsync(Album album);
    Task<List<Album>> GetAllAsync();
    Task<Album> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(int id, Album album);
    Task<bool> ExistsByIdAsync(int id);
    Task<bool> ExistsByTitleAsync(string title);
}