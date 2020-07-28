using System.Collections.Generic;
using Commander.Interface;
using Commander.Models;
using System;
using Commander.Repository;
using Commander.Error;
using System.Threading.Tasks;

namespace Commander.Service
{
  public class CommandService : ICommandService
  {

    private readonly ICommandRepository _commandRepository;

    public CommandService(ICommandRepository commandRepository)
    {
      _commandRepository = commandRepository;
    }

    public async Task<IEnumerable<Command>> GetAllCommands()
    {
      return await _commandRepository.GetAll();
    }

    public async Task<Command> GetCommandById(int id)
    {
      var result = await _commandRepository.GetById(id);

      if (result is null) throw new NotFoundException("Comando não encontrado.");

      return result;
    }

    public async Task InsertCommand(Command command)
    {
      await _commandRepository.Insert(command);
    }

    public async Task<Command?> DeleteCommand(int id)
    {
      return await _commandRepository.Delete(id);
    }
  }
}