using AutoMapper;
using EliteCare.Core.Features.Nurse.Queries.Models;
using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurse.Queries.Handlers
{
    public class NurseQueryHandler : IRequestHandler<GetAllNurse, ApiResultResponse<List<TemplateNurse>>>,
                                       IRequestHandler<GetNurseById, ApiResultResponse<TemplateNurse>>,
                                       IRequestHandler<GetNurseByEmail, ApiResultResponse<TemplateNurse>>,
                                       IRequestHandler<GetNursesGovernRoom, ApiResultResponse<List<TemplateNurse>>>
    {
        public INurseService _nurseService { get; set; }
        public IMapper Mapper { get; set; }

        public NurseQueryHandler(INurseService nurseService, IMapper mapper)
        {
            _nurseService = nurseService;
            Mapper = mapper;
        }

        public async Task<ApiResultResponse<List<TemplateNurse>>> Handle(GetAllNurse request, CancellationToken cancellationToken)
        {

            var nurses =await  _nurseService.GetAllNurse();
            var mappedNurse = Mapper.Map<List<TemplateNurse>>(nurses);
            return nurses.Count() > 0 ? new ApiResultResponse<List<TemplateNurse>>(200, mappedNurse) :
                                        new ApiResultResponse<List<TemplateNurse>>(404, null);
        }

        public async Task<ApiResultResponse<TemplateNurse>> Handle(GetNurseById request, CancellationToken cancellationToken)
        {
            var nurse = await _nurseService.GetNurseByIdSpec(request.Id);

            var mappedNurse = Mapper.Map<TemplateNurse>(nurse);

            return nurse is not null ? new ApiResultResponse<TemplateNurse>(200, mappedNurse) :
                                        new ApiResultResponse<TemplateNurse>(404, null);
        }

        public async Task<ApiResultResponse<TemplateNurse>> Handle(GetNurseByEmail request, CancellationToken cancellationToken)
        {
            var nurse = await _nurseService.GetNurseByEmailSpec(request.Email);
            var mappedNurse = Mapper.Map<TemplateNurse>(nurse);

            return nurse is not null ? new ApiResultResponse<TemplateNurse>(200, mappedNurse) :
                                        new ApiResultResponse<TemplateNurse>(404, null);
        }

        public async Task<ApiResultResponse<List<TemplateNurse>>> Handle(GetNursesGovernRoom request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseService.GetNursesGovernRoom(request.RoomId);

            var mappedNurse = Mapper.Map<List<TemplateNurse>>(nurses);
            return nurses.Count() > 0 ? new ApiResultResponse<List<TemplateNurse>>(200, mappedNurse) :
                                        new ApiResultResponse<List<TemplateNurse>>(404, null);
        }
    }
}
