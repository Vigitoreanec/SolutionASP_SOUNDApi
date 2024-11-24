
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Beautify.Application.Interfaces;

public interface IBeautifyDbContext
{
    DbSet<Group> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
