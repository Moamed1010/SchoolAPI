using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Quaries.Models;
using School.Data.AppMetaData;

namespace School.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudnetController : AppControllerBase
    {


        [HttpGet(Router.StudentRouting.GetAll)]
        public async Task<IActionResult> GetStudentList()
        {
            var result = await Mediator.Send(new GetStudentListQuery());
            return Ok(result);
        }
        [HttpGet(Router.StudentRouting.paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById(int id)
        {

            return NewResult(await Mediator.Send(new GetStudentByIdQuery(id)));
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);

        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);

        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var result = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(result);
        }
    }
}
