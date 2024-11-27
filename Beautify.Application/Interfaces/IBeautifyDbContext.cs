
using Microsoft.EntityFrameworkCore;
using Beautify.Domain;

namespace Beautify.Application.Interfaces;

public interface IBeautifyDbContext
{
    DbSet<Group> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
