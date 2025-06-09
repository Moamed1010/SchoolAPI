using MediatR;
using School.Core.Basecs;

namespace School.Core.Features.Department.Commands.Models
{
    public class AddDepartmentCommand : IRequest<Response<string>>
    {
        public string DNameAr { get; set; }
        public string DNameEn { get; set; }
        public int ManagerId { get; set; }

    }
}
