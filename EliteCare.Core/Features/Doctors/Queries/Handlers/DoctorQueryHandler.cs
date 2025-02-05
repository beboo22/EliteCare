using AutoMapper;
using EliteCare.Core.Features.Doctors.Queries.Models;
using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Queries.Handlers
{
    public class DoctorQueryHandler : IRequestHandler<GetAllDoctor, ApiResultResponse<List<TemplateDoctor>>>,
                                      IRequestHandler<GetDoctorById, ApiResultResponse<TemplateDoctor>>,
                                      IRequestHandler<GetDoctorsForDept, ApiResultResponse<List<TemplateDoctor>>>,
                                      IRequestHandler<GetDoctorByEmail,ApiResultResponse<TemplateDoctor>>,
                                      IRequestHandler<GetSpecialistDoctorInDept,ApiResultResponse<List<TemplateDoctor>>>
    {
        IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorQueryHandler(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        public async Task<ApiResultResponse<TemplateDoctor>> Handle(GetDoctorById request, CancellationToken cancellationToken)
        {
            var item = await _doctorService.GetDoctorByIdSpec(request.Id);

            if (item is null)
                return new ApiResultResponse<TemplateDoctor>(404, null, "Doctor not found");

            var mappedItem = _mapper.Map<TemplateDoctor>(item);
            return new ApiResultResponse<TemplateDoctor>(200, mappedItem);


        }

        public async Task<ApiResultResponse<List<TemplateDoctor>>> Handle(GetAllDoctor request, CancellationToken cancellationToken)
        {
            var items = await _doctorService.GetAllDoctor();

            if (!items.Any())
                return new ApiResultResponse<List<TemplateDoctor>>(404, null, "No doctors found");

            var mappedItems = _mapper.Map<List<TemplateDoctor>>(items);
            return new ApiResultResponse<List<TemplateDoctor>>(200, mappedItems);
        }

        public async Task<ApiResultResponse<List<TemplateDoctor>>> Handle(GetDoctorsForDept request, CancellationToken cancellationToken)
        {
            var items = await _doctorService.GetDoctorForDept(request.DepartmentId);

            if (!items.Any())
                return new ApiResultResponse<List<TemplateDoctor>>(404, null, "No doctors found");

            var mappedItems = _mapper.Map<List<TemplateDoctor>>(items);
            return new ApiResultResponse<List<TemplateDoctor>>(200, mappedItems);
        }

        public async Task<ApiResultResponse<TemplateDoctor>> Handle(GetDoctorByEmail request, CancellationToken cancellationToken)
        {
            var item = await _doctorService.GetDoctorByEmailSpec(request.Email);

            if (item is null)
                return new ApiResultResponse<TemplateDoctor>(404, null, "Doctor not found");

            var mappedItem = _mapper.Map<TemplateDoctor>(item);
            return new ApiResultResponse<TemplateDoctor>(200, mappedItem);
        }

        public async Task<ApiResultResponse<List<TemplateDoctor>>> Handle(GetSpecialistDoctorInDept request, CancellationToken cancellationToken)
        {
            var items = await _doctorService.SpecialistDoctorInDepartment(request.DepartmentId);

            if (!items.Any())
                return new ApiResultResponse<List<TemplateDoctor>>(404, null, "No doctors found");

            var mappedItems = _mapper.Map<List<TemplateDoctor>>(items);
            return new ApiResultResponse<List<TemplateDoctor>>(200, mappedItems);
        }
    }
}
