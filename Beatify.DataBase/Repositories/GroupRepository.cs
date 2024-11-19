
using Beatify.DataBase.Data;
using Beatify.DataBase.Entities;
using Beatify.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Beatify.DataBase.Repositories;

public class GroupRepository(BeatifyDBContext beatifyDBContext) : IGroupRepository
{

    public async Task<List<Group>> GetAllAsync() =>
        await beatifyDBContext.Groups.ToListAsync();

    public async Task<Group> GetById(int id) =>
        await beatifyDBContext.Groups.SingleAsync(g => g.Id == id);

    public async Task AddAsync(Group group)
    {
        await beatifyDBContext.AddAsync(group);
        await beatifyDBContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await beatifyDBContext.Groups
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();

    }
    public async Task UpdateAsync(int id, Group group)
    {
        await beatifyDBContext.Groups
            .Where(group => group.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(g => g.Title, group.Title)
                .SetProperty(g => g.UrlImage, group.UrlImage)
                .SetProperty(g => g.Description, group.Description)
                .SetProperty(g => g.FoundationDate, group.FoundationDate)
                .SetProperty(g => g.Genres, group.Genres)
                .SetProperty(g => g.Albums, group.Albums)
            );
    }
}
