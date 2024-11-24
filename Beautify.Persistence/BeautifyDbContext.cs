using Beautify.Application.Interfaces;
using Beautify.PersistenceDb.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Beautify.PersistenceDb;

public class BeautifyDbContext(DbContextOptions<BeautifyDbContext> options) : DbContext(options), IBeautifyDbContext
{
    public DbSet<Group> Groups { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
