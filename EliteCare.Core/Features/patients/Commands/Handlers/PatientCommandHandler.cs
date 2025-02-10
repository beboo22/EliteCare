using AutoMapper;
using EliteCare.Core.Features.patients.Commands.Models;
using EliteCare.Core.Features.Receptionists.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Commands.Handlers
{
    public class PatientCommandHandler : IRequestHandler<DeletePatientCommand, ApiResponse>,
                                                IRequestHandler<UpdatePatientCommand, ApiResponse>,
                                                IRequestHandler<AddPatientCommand, ApiResponse>
    {
        IPatientService service { get; set; }
        IMapper mapper { get; set; }

        public PatientCommandHandler(IPatientService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var res = await service.DeletePatientAsync(request.Id);
            return res;
        }

        public async Task<ApiResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var mappedRece = mapper.Map<Patient>(request.patientDto);
            var mappedAddress = mapper.Map<Address>(request.patientDto.Address);


            var res = await service.UpdatePatientAsync(mappedRece, mappedAddress);
            return res;
        }

        public Task<ApiResponse> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var mappedRece = mapper.Map<Patient>(request.patientDto);
            var mappedAddress = mapper.Map<Address>(request.patientDto.Address);

            var res = service.AddPatientAsync(mappedRece, mappedAddress);
            return res;
        }
    }
}
