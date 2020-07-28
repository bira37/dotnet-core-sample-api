using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Interface
{
  public interface ICommandService
  {
    Task<IEnumerable<Command>> GetAllCommands();

    Task<Command> GetCommandById(int id);

    Task InsertCommand(Command command);

    Task<Command?> DeleteCommand(int id);
  }
}