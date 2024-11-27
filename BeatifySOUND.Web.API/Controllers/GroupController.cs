using Beautify.Application.Groups.Queries.GetGroupList;
using BeautifySOUND.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;



namespace BeatifySOUND.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : BaseController
{
    [HttpGet]
   public async Task<ActionResult<GroupListViewModel>> GetAll(int countSkip,int countTake)
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
}
