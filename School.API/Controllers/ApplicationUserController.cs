using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.ApplicationUser.Commands.Models;
using Router = School.Data.AppMetaData.Router;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
    }
}
