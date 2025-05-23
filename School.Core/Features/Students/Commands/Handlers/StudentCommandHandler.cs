using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Basecs;
using School.Core.Features.Students.Commands.Models;
using School.Core.Resources;
using School.Data.Models;
using School.service.Abstracts;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                        IRequestHandler<AddStudentCommand, Response<string>>,
                                        IRequestHandler<EditStudentCommand, Response<string>>,
                                        IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        #region Fildes
        private readonly service.Abstracts.IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Ctor
        public StudentCommandHandler(IStudentService studentService,
                                        IMapper mapper,
                                      IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;

        }
        #endregion
        #region Handel function

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentmapper);

            if (result)
                return Created(_stringLocalizer[SharedResourcesKeys.Successed].Value);
            else
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest].Value);
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentService.EditAsync(student);

            if (result)
                return Success(_stringLocalizer[SharedResourcesKeys.Updated].Value);
            else
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest].Value);
        }


        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>($"Deleted Successfully {request.Id}");
            else return base.BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);

        }
        #endregion

    }
}
