using AutoMapper;
using EliteCare.Core.BaseResponse;
using EliteCare.Core.Features.Doctors.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Commands.Handlers
{
    internal class DoctorCommandHandler : IRequestHandler<AddDoctorCommand, ApiResultResponse<String>>,
                                          IRequestHandler<UpdateDoctorCommand, ApiResultResponse<String>>,
                                          IRequestHandler<DeleteDoctorCommand, ApiResultResponse<String>>
    {
        IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorCommandHandler(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        public async Task<ApiResultResponse<string>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var mappedDoctor = _mapper.Map<Doctor>(request.doctorDtos);
            var mappedAddress = _mapper.Map<Address>(request.doctorDtos.address);

            var flag = await _doctorService.AddDoctorAsync(mappedDoctor, mappedAddress);
            if (!flag)
                return new ApiResultResponse<string>(400, "Doctor not added");
       
            return new ApiResultResponse<string>(200, "Doctor added successfully");

        }

        public async Task<ApiResultResponse<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var mappedDoctor = _mapper.Map<Doctor>(request.doctorDtos);
            var mappedAddress = _mapper.Map<Address>(request.doctorDtos.address);

            var flag = await _doctorService.UpdateDoctorAsync(mappedDoctor, mappedAddress);
            if (!flag)
                return new ApiResultResponse<string>(400, "Doctor not Updated");

            return new ApiResultResponse<string>(200, "Doctor Updated successfully");
        }

        public async Task<ApiResultResponse<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var flag = await _doctorService.DeleteDoctorAsync(request.Id);
            if (!flag)
                return new ApiResultResponse<string>(400, "Doctor not deleted");
            return new ApiResultResponse<string>(200, "Doctor deleted successfully");
        }
    }
}
