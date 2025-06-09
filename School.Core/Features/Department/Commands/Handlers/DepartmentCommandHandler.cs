using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Basecs;
using School.Core.Features.Department.Commands.Models;

using School.Core.Resources;
using School.service.Abstracts;

namespace School.Core.Features.Department.Commands.Handlers
{
    public class DepartmentCommandHandler : ResponseHandler,
                                         IRequestHandler<AddDepartmentCommand, Response<string>>,
                                         IRequestHandler<EditDepartmentCommand, Response<string>>,
                                          IRequestHandler<DeleteDepartmentCommand, Response<string>>
    {
        #region Fildes
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        public DepartmentCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, IDepartmentService departmentService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<School.Data.Models.Department>(request);


            var result = await _departmentService.AddAsync(department);

            if (result)
                return Created(_stringLocalizer[SharedResourcesKeys.Successed].Value);
            else
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest].Value);
        }

        public async Task<Response<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentById(request.Id);

            if (department == null)
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);


            department.DNameAr = request.DNameAr;
            department.DNameEn = request.DNameEn;
            department.InsManager = request.ManagerId;

            var updated = await _departmentService.UpdateAsync(department);

            if (updated)
                return Success(_stringLocalizer[SharedResourcesKeys.Updated].Value);
            else
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
        }
        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentById(request.Id);
            if (department == null)
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = await _departmentService.DeleteAsync(department);

            if (result)
                return Success(_stringLocalizer[SharedResourcesKeys.Deleted].Value);
            else
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest].Value);
        }

    }

}
