using AutoMapper;
using EliteCare.Core.Features.Appointments.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Commands.Handlers
{
    public class AppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, ApiResponse>,
                                               IRequestHandler<UpdateAppointmentCommand, ApiResponse>,
                                               IRequestHandler<DeleteAppointmentCommand, ApiResponse>
    
    {
        public IAppointmentService service { get; set; }
        public IMapper mapper { get; set; }
        public AppointmentCommandHandler(IAppointmentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var mappedAppointments = mapper.Map<Appointment>(request.appointmentDtos);

            var res = await service.AddAppointment(mappedAppointments);
            return res;
        }

        public async Task<ApiResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var mappedAppointments = mapper.Map<Appointment>(request.appointmentDtos);

            var res = await service.UpdateAppointment(mappedAppointments);
            return res;
        }

        public async Task<ApiResponse> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {

            var res = await service.DeleteAppointment(request.ID);
            return res;
        }
    }
}
