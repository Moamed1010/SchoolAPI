using MediatR;
using School.Core.Basecs;
using School.Core.Features.Department.Quaries.Results;

namespace School.Core.Features.Department.Quaries.Models
{
    public class GetDepartmentByIDQueryModel : IRequest<Response<GetDepartmentByIDQueryResponse>>
    {
        public int ID { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }

    }

}
