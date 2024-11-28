using Beautify.Domain;
using Microsoft.EntityFrameworkCore;

namespace Beautify.Application.Interfaces;

public interface IBeautifyDbContext
{
    DbSet<GroupNEW> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
