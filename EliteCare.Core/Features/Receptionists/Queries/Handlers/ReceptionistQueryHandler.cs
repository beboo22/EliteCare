using AutoMapper;
using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Receptionists.Queries.Models;
using EliteCare.Core.Features.Receptionists.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Queries.Handlers
{
    public class ReceptionistQueryHandler : IRequestHandler<GetAllAppointmentsForReceptionist, ApiResponse>,
                                                IRequestHandler<GetByEmailReceptionistQuery, ApiResponse>,
                                                IRequestHandler<GetByIdReceptionistQuery, ApiResponse>,
                                                IRequestHandler<GetAllReceptionistQuery, ApiResponse>
    {
        IReceptionistService service { get; set; }
        IMapper mapper { get; set; }

        public ReceptionistQueryHandler(IReceptionistService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetAllReceptionistQuery request, CancellationToken cancellationToken)
        {
            var items = await service.GetAllReceptionist();
            var mappedRec = mapper.Map < List<TemplateReceptionist>>(items);

            return items.Any() is true ? new ApiResultResponse<List<TemplateReceptionist>>(200,mappedRec) : new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetByEmailReceptionistQuery request, CancellationToken cancellationToken)
        {
            var items = await service.GetReceptionistByEmail(request.email);
            var mappedRec = mapper.Map<TemplateReceptionist>(items);

            return items is not null ? new ApiResultResponse<TemplateReceptionist>(200, mappedRec) : new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetByIdReceptionistQuery request, CancellationToken cancellationToken)
        {
            var items = await service.GetReceptionistByIdSpec(request.id);
            var mappedRec = mapper.Map<TemplateReceptionist>(items);

            return items is not null ? new ApiResultResponse<TemplateReceptionist>(200, mappedRec) : new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetAllAppointmentsForReceptionist request, CancellationToken cancellationToken)
        {
            var appointments = await service.GetAppointmentsForReceptionist(request.Id);

            if (!appointments.Any())
                return new ApiResponse(404, "not Found Appointment For Receptionist");
            
            var mappedAppointment = mapper.Map<List<AppointmentReturnDto>>(appointments);
            var mappedTemplate = new TemplateForAppointment_Receptionist() { ReceptionistId = request.Id, Appointment =  mappedAppointment };


            return new ApiResultResponse<TemplateForAppointment_Receptionist>(200,mappedTemplate);



        }
    }
}
