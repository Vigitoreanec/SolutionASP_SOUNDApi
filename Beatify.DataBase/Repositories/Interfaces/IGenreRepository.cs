using Beatify.DataBase.Entities;

namespace Beatify.DataBase.Repositories.Interfaces;

public interface IGenreRepository
{
    Task AddAsync(Genre genre);
    Task<List<Genre>> GetAllAsync();
    Task<Genre> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(int id, Genre genre);
    Task<bool> ExistsByIdAsync(int id);
    Task<bool> ExistsByTitleAsync(string title);
}