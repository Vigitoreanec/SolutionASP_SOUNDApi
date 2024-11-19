using Beatify.DataBase.Entities;

namespace Beatify.DataBase.Repositories.Interfaces;

public interface IGroupRepository
{
    Task AddAsync(Group group);
    Task<List<Group>> GetAllAsync();
    Task<Group> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(int id, Group group);
}