using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.ApplicationUser.Commands.Models;
using School.Core.Features.ApplicationUser.Queries.Models;
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

        [HttpGet(Router.ApplicationUserRouting.paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);
        }
        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);

        }

        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(result);

        }
    }
}
