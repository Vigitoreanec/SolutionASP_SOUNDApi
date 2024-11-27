using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeautifySOUND.Web.API.Controllers;
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
   private IMediator? mediator;
    protected IMediator? Mediator => 
        mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
