using AutoMapper;
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

namespace EliteCare.Core.Features.Receptionists.Commands.Handlers
{
    public class ReceptionistCommandHandler : IRequestHandler<DeleteReceptionistsCommand, ApiResponse>,
                                                IRequestHandler<UpdateReceptionistsCommand, ApiResponse>,
                                                IRequestHandler<AddReceptionistsCommand, ApiResponse>
    {
        IReceptionistService service { get; set; }
        IMapper mapper { get; set; }

        public ReceptionistCommandHandler(IReceptionistService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public Task<ApiResponse> Handle(DeleteReceptionistsCommand request, CancellationToken cancellationToken)
        {
            var res = service.DeleteReceptionistAsync(request.Id);
            return res;
        }

        public Task<ApiResponse> Handle(UpdateReceptionistsCommand request, CancellationToken cancellationToken)
        {
            var mappedRece = mapper.Map<Receptionist>(request.receptionistDto);
            var mappedAddress = mapper.Map<Address>(request.receptionistDto.Address);


            var res = service.UpdateReceptionistAsync(mappedRece, mappedAddress);
            return res;
        }

        public Task<ApiResponse> Handle(AddReceptionistsCommand request, CancellationToken cancellationToken)
        {
            var mappedRece = mapper.Map<Receptionist>(request.receptionistDto);
            var mappedAddress = mapper.Map<Address>(request.receptionistDto.Address);

            var res = service.AddReceptionistAsync(mappedRece, mappedAddress);
            return res;
        }
    }
}
