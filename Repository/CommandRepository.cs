using Microsoft.EntityFrameworkCore;
using Commander.Models;
using System.Collections.Generic;
using Commander.Database;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Commander.Repository
{
  public interface ICommandRepository
  {
    Task<List<Command>> GetAll();
    Task<Command?> GetById(int id);
    Task Insert(Command command);
    Task<Command?> Delete(int id);
  }
  public class CommandRepository : ICommandRepository
  {
    private readonly DbContext Context;
    private readonly DbSet<Command> Set;
    public CommandRepository(DatabaseContext context)
    {
      Context = context;
      Set = context.Set<Command>();
    }

    public async Task<List<Command>> GetAll()
    {
      return await Set.ToListAsync();
    }

    public async Task<Command?> GetById(int id)
    {
      return await Set.FirstOrDefaultAsync(command => command.Id.Equals(id));
    }

    public async Task Insert(Command command)
    {
      await Set.AddAsync(command);
      await Context.SaveChangesAsync();
    }

    public async Task<Command?> Delete(int id)
    {
      var command = await Set.FindAsync(id);

      if (command is null)
      {
        return null;
      }

      var result = Set.Remove(command).Entity;

      await Context.SaveChangesAsync();

      return result;

    }
  }
}