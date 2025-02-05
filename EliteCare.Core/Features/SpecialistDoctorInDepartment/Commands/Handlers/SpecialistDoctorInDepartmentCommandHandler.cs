using AutoMapper;
using EliteCare.Core.Features.SpecialistDoctorInDepartment.Commands.Models;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartment.Commands.Handlers
{
    public class SpecialistDoctorInDepartmentCommandHandler : IRequestHandler<AddSpecialistDoctorCommand, ApiResponse>
    {
        public ISpecialistDoctorInDepartmentService specialist { get; set; }
        IMapper mapper { get; set; }

        public SpecialistDoctorInDepartmentCommandHandler(ISpecialistDoctorInDepartmentService specialist, IMapper mapper)
        {
            this.specialist = specialist;
            this.mapper = mapper;
        }
        public Task<ApiResponse> Handle(AddSpecialistDoctorCommand request, CancellationToken cancellationToken)
        {
            var mappedItem = mapper.Map < EliteCare.Data.Entities.SpecialistDoctorInDepartment>(request.SpecialistDoctorDtos);
            var flag = specialist.AddSpecialistDoctorInDepartment(mappedItem);
            return flag;
        }
    }
}
