using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #region Constructors
        public StudentCommandHandler(IStudentService studentService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping betwen request annd student
            var studentmapper = _mapper.Map<Student>(request);

            //add
            var result = await _studentService.AddAsync(studentmapper);

            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check is the id is exist or not
            var student = await _studentService.GetByIDAsync(request.Id);

            //return not found
            if (student == null) return NotFound<string>(_localizer[SharedResourcesKey.NotFound]);
            //mapping between request and student
            var studentmapper = _mapper.Map(request, student);
            //call service that make edit
            var result = await _studentService.EditAsync(studentmapper);
            //return response 
            if (result == "Success") return Success($"Edit Successfully {studentmapper.StudID}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check is the id is exist or not
            var student = await _studentService.GetByIDAsync(request.Id);
            //return not found
            if (student == null) return NotFound<string>(_localizer[SharedResourcesKey.NotFound]);
            //call service that make Delete
            var result = await _studentService.DeleteAsync(student);
            //return response 
            if (result == "Success") return Deleted<string>($"Delete Successfully {request.Id}");
            else return BadRequest<string>();
        }
    }
}
