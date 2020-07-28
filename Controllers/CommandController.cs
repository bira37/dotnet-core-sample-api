using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Interface;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Error;

namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandController : ControllerBase
  {

    private readonly ICommandService _service;

    public CommandController(ICommandService commandService)
    {
      _service = commandService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Command>), 200)]
    public async Task<IEnumerable<CommandDto>> GetAllCommands()
    {
      var commandItems = await _service.GetAllCommands();
      return commandItems;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Command), 200)]
    [ProducesResponseType(typeof(NotFoundException), 404)]
    public async Task<CommandDto> GetCommandById(int id)
    {
      var commandItem = await _service.GetCommandById(id);
      return commandItem;
    }

    [HttpPost]
    public async Task InsertCommand([FromBody] Command command)
    {
      await _service.InsertCommand(command);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Command), 200)]
    public async Task<CommandDto?> DeleteCommand(int id)
    {
      return await _service.DeleteCommand(id);
    }
  }
}