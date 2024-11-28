using AutoMapper;
using Beautify.Application.Groups.Commands.CreateGroup;
using Beautify.Application.Groups.Commands.DeleteGroup;
using Beautify.Application.Groups.Commands.UpdateGroup;
using Beautify.Application.Groups.Queries.GetGroupDetails;
using Beautify.Application.Groups.Queries.GetGroupList;
using BeautifySOUND.Web.API;
using BeautifySOUND.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace BeatifySOUND.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GroupListViewModel>> GetAll(int countSkip, int countTake)
    {
        var query = new GetGroupListQuery
        {
            CountSkipGroups = countSkip,
            CountTakeGroups = countTake,
        };

        if (Mediator is null)
        {
            throw new NullReferenceException("Mediator is null");
        }
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<GroupListViewModel>> Get(int id)
    {
        var query = new GetGroupDetailsQuery { Id = id };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateGroupDTO createGroupDTO)
    {
        var commandMapper = mapper.Map<CreateGroupCommand>(createGroupDTO);
        
        if (Mediator is null)
        {
            throw new NullReferenceException("MediatorCreate is null");
        }

        var id = await Mediator.Send(commandMapper);
        return Ok(id);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGroupDTO updateGroupDTO)
    {
        var command = mapper.Map<UpdateGroupCommand>(updateGroupDTO);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteGroupCommand { Id = id };
        await Mediator.Send(command);
        //return NoContent();
        return Ok();
    }
}
