using AutoMapper;
using EliteCare.Core.Features.Doctors.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Commands.Handlers
{
    public class DoctorCommandHandler : IRequestHandler<AddDoctorCommand, ApiResponse>,
                                        IRequestHandler<UpdateDoctorCommand, ApiResponse>,
                                        IRequestHandler<DeleteDoctorCommand, ApiResponse>
                                        //IRequestHandler<AddSpecialistDoctorCommand, ApiResponse>
    {
        IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorCommandHandler(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var mappedDoctor = _mapper.Map<Doctor>(request.doctorDtos);
            var mappedAddress = _mapper.Map<Address>(request.doctorDtos.address);

            var flag = await _doctorService.AddDoctorAsync(mappedDoctor, mappedAddress);

            return flag??new ApiResponse(500);

        }

        public async Task<ApiResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var mappedDoctor = _mapper.Map<Doctor>(request.doctorDtos);
            var mappedAddress = _mapper.Map<Address>(request.doctorDtos.address);

            var flag = await _doctorService.UpdateDoctorAsync(mappedDoctor, mappedAddress);
            return new ApiResponse(flag.statusCode, flag.message);
        }

        public async Task<ApiResponse> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var flag = await _doctorService.DeleteDoctorAsync(request.Id);
            return new ApiResponse(flag.statusCode, flag.message);
        }

    }
}
