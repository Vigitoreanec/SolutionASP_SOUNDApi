using Beatify.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beatify.DataBase.Data;

public class BeatifyDBContext (DbContextOptions<BeatifyDBContext> options) : DbContext(options)
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Genre> Genres { get; set; }
}



