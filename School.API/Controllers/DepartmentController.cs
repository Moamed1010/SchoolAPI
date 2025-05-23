using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Department.Quaries.Models;
using School.Data.AppMetaData;

namespace School.API.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {

        [HttpGet(Router.DepartmentRouting.GetById)]

        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIDQueryModel query)
        {


            return NewResult(await Mediator.Send(query));
        }


    }
}
