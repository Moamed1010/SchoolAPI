using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Basecs;
using School.Core.Features.Department.Quaries.Models;
using School.Core.Features.Department.Quaries.Results;
using School.Core.Resources;
using School.Core.Wrappers;
using School.Data.Models;
using School.service.Abstracts;
using System.Linq.Expressions;

namespace School.Core.Features.Department.Quaries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIDQueryModel, Response<GetDepartmentByIDQueryResponse>>
    {


        #region Fieds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer
                                     , IDepartmentService departmentService
                                                , IMapper mapper
                                                , IStudentService studentService)
                                            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;

        }


        #endregion
        #region Handle Function
        public async Task<Response<GetDepartmentByIDQueryResponse>> Handle(GetDepartmentByIDQueryModel request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetDepartmentById(request.ID);

            if (response == null)
            {
                return NotFound<GetDepartmentByIDQueryResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var mapper = _mapper.Map<GetDepartmentByIDQueryResponse>(response);
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudentByDepartmentIDQueryable(request.ID);
            var PaginatedList = await studentQuerable.Select(expression)
                .ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = PaginatedList;

            return Success(mapper);

        }
        #endregion

    }

}
