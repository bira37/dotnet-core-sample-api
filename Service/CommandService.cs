using System.Collections.Generic;
using Commander.Interface;
using Commander.Models;
using System;
using Commander.Repository;
using Commander.Error;
using System.Threading.Tasks;
using Commander.Dtos;

namespace Commander.Service
{
  public class CommandService : ICommandService
  {

    private readonly ICommandRepository _commandRepository;

    public CommandService(ICommandRepository commandRepository)
    {
      _commandRepository = commandRepository;
    }

    public async Task<List<CommandDto>> GetAllCommands()
    {
      var commands = await _commandRepository.GetAll();
      return commands.ConvertAll(ConvertModelToDto);
    }

    public async Task<CommandDto> GetCommandById(int id)
    {
      var result = await _commandRepository.GetById(id);

      if (result is null) throw new NotFoundException("Comando não encontrado.");

      return ConvertModelToDto(result);
    }

    public async Task InsertCommand(Command command)
    {
      await _commandRepository.Insert(command);
    }

    public async Task<CommandDto?> DeleteCommand(int id)
    {
      var deleted = await _commandRepository.Delete(id);

      if (deleted is null)
      {
        return null;
      }

      return ConvertModelToDto((await _commandRepository.Delete(id))!);

    }

    private static CommandDto ConvertModelToDto(Command command)
    {
      return new CommandDto
      {
        Id = command.Id,
        HowTo = command.HowTo,
        Platform = command.Platform,
        Line = command.Line
      };
    }
  }
}