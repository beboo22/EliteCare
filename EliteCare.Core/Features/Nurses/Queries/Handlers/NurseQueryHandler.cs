using AutoMapper;
using EliteCare.Core.Features.Nurse.Queries.Models;
using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurse.Queries.Handlers
{
    public class NurseQueryHandler : IRequestHandler<GetAllNurse, ApiResponse>,
                                     IRequestHandler<GetNurseById, ApiResponse>,
                                     IRequestHandler<GetNurseByEmail, ApiResponse>,
                                     IRequestHandler<GetNursesGovernRoom, ApiResponse>
    {
        public INurseService _nurseService { get; set; }
        public IMapper Mapper { get; set; }

        public NurseQueryHandler(INurseService nurseService, IMapper mapper)
        {
            _nurseService = nurseService;
            Mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetAllNurse request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseService.GetAllNurse();
            var mappedNurse = Mapper.Map<List<TemplateNurse>>(nurses);
            return nurses.Count() > 0 ? new ApiResultResponse<List<TemplateNurse>>(200, mappedNurse) :
                                        new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetNurseById request, CancellationToken cancellationToken)
        {
            var nurse = await _nurseService.GetNurseByIdSpec(request.Id);

            var mappedNurse = Mapper.Map<TemplateNurse>(nurse);

            return nurse is not null ? new ApiResultResponse<TemplateNurse>(200, mappedNurse) :
                                       new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetNurseByEmail request, CancellationToken cancellationToken)
        {
            var nurse = await _nurseService.GetNurseByEmailSpec(request.Email);
            var mappedNurse = Mapper.Map<TemplateNurse>(nurse);

            return nurse is not null ? new ApiResultResponse<TemplateNurse>(200, mappedNurse) :
                                       new ApiResponse(404);


        }

        public async Task<ApiResponse> Handle(GetNursesGovernRoom request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseService.GetNursesGovernRoom(request.RoomId);

            var mappedNurse = Mapper.Map<List<TemplateNurse>>(nurses);
            return nurses.Count() > 0 ? new ApiResultResponse<List<TemplateNurse>>(200, mappedNurse) :
                                        new ApiResponse(404);

        }
    }
}
