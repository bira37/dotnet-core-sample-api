using Microsoft.EntityFrameworkCore;
using Commander.Models;

namespace Commander.Database
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Command> Command { get; set; } = null!;
  }
}