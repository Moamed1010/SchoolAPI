using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Department.Commands.Models;
using School.Core.Features.Department.Quaries.Models;
using School.Data.AppMetaData;

namespace School.API.Controllers
{

    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetAll)]
        public async Task<IActionResult> GetDepartmentList()
        {
            var result = await Mediator.Send(new GetDepartmentListQuery());
            return Ok(result);
        }


        [HttpGet(Router.DepartmentRouting.GetById)]

        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIDQueryModel query)
        {

            return NewResult(await Mediator.Send(query));
        }
        [HttpPost(Router.DepartmentRouting.Create)]
        public async Task<IActionResult> Create([FromQuery] AddDepartmentCommand command)
        {
            return NewResult(await Mediator.Send(command));

        }

        [HttpPut(Router.DepartmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDepartmentCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete(Router.DepartmentRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteDepartmentCommand(id));
            return NewResult(result);
        }




    }
}
