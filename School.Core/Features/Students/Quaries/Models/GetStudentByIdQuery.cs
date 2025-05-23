using MediatR;
using School.Core.Basecs;
using School.Core.Features.Students.Quaries.Results;
using School.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Quaries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

    }
}
