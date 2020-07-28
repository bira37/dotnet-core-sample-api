using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;
using Commander.Dtos;

namespace Commander.Interface
{
  public interface ICommandService
  {
    Task<List<CommandDto>> GetAllCommands();

    Task<CommandDto> GetCommandById(int id);

    Task InsertCommand(Command command);

    Task<CommandDto?> DeleteCommand(int id);
  }
}