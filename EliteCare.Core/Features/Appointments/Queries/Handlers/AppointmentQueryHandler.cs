using AutoMapper;
using EliteCare.Core.Features.Appointments.Queries.Models;
using EliteCare.Core.Features.Appointments.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Queries.Handlers
{
    public class AppointmentQueryHandler : IRequestHandler<GetAllAppointmentQuery, ApiResponse>,
                                             IRequestHandler<GetByIdAppointmentQuery, ApiResponse>
    {

        public IAppointmentService service { get; set; }
        public IMapper mapper { get; set; }
        public AppointmentQueryHandler(IAppointmentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }




        public async Task<ApiResponse> Handle(GetByIdAppointmentQuery request, CancellationToken cancellationToken)
        {
            var items = await service.GetAppointmentById(request.Id);

            var mappedres = mapper.Map<TemplateAppointment>(items);
            return items is not null ? new ApiResultResponse<TemplateAppointment>(200, mappedres) :
                                         new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var items = await service.GetAppointment();

            var mappedres = mapper.Map<List<TemplateAppointment>>(items);
            return items.Any() is true ? new ApiResultResponse<List<TemplateAppointment>>(200, mappedres) :
                                         new ApiResponse(404);
        }
    }
}
