using AutoMapper;
using EliteCare.Core.Features.SpecialistDoctorInDepartments.Commands.Models;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartments.Commands.Handlers
{
    public class SpecialistDoctorInDepartmentCommandHandler : IRequestHandler<AddSpecialistDoctorCommand, ApiResponse>,
                                                              IRequestHandler<UpdateSpecialistDoctorCommand, ApiResponse>,
                                                              IRequestHandler<DeleteSpecialistDoctorCommand, ApiResponse>
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

        public Task<ApiResponse> Handle(DeleteSpecialistDoctorCommand request, CancellationToken cancellationToken)
        {
            var flag = specialist.DeleteSpecialistDoctorInDepartment(request.DoctorID);
            return flag;
        }

        public Task<ApiResponse> Handle(UpdateSpecialistDoctorCommand request, CancellationToken cancellationToken)
        {
            var mappedItem = mapper.Map<EliteCare.Data.Entities.SpecialistDoctorInDepartment>(request.SpecialistDoctorDtos);
            var flag = specialist.UpdateSpecialistDoctorInDepartment(mappedItem);
            return flag;
        }
    }
}
