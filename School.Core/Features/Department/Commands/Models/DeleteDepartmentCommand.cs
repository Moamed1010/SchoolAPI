using MediatR;
using School.Core.Basecs;

namespace School.Core.Features.Department.Commands.Models
{


    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {

        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;

        }
    }
}
