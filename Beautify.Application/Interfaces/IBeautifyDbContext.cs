using Beautify.Domain;
using Microsoft.EntityFrameworkCore;

namespace Beautify.Application.Interfaces;

public interface IBeautifyDbContext
{
    DbSet<Group> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
