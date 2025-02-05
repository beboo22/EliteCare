using AutoMapper;
using EliteCare.Core.Features.Nurses.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurses.Commands.Handlers
{
    public class NurseCommandHandler : IRequestHandler<AddNurseCommand, ApiResponse>,
                                       IRequestHandler<UpdateNurseCommand, ApiResponse>,
                                       IRequestHandler<DeleteNurseCommand, ApiResponse>
    {
        INurseService _nurseService;
        IMapper _mapper;
        public NurseCommandHandler(INurseService nurseService, IMapper mapper)
        {
            _nurseService = nurseService;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(AddNurseCommand request, CancellationToken cancellationToken)
        {
            var mappedNurse = _mapper.Map<EliteCare.Data.Entities.Nurse>(request.addNurse);
            var mappedAddress = _mapper.Map<Address>(request.addNurse.Address);

            var check = await _nurseService.AddNurseAsync(mappedNurse, mappedAddress);
            return check ?? new ApiResponse(500);
        }

        public async Task<ApiResponse> Handle(UpdateNurseCommand request, CancellationToken cancellationToken)
        {
            var mappedNurse = _mapper.Map<EliteCare.Data.Entities.Nurse>(request.updateNurse);
            var mappedAddress = _mapper.Map<Address>(request.updateNurse.Address);

            var check = await _nurseService.UpdateNurseAsync(mappedNurse, mappedAddress);
            return check ?? new ApiResponse(500);
        }

        public async Task<ApiResponse> Handle(DeleteNurseCommand request, CancellationToken cancellationToken)
        {
            var check = await _nurseService.DeleteNurseAsync(request.id);
            return check ?? new ApiResponse(500);
        }
    }
}
