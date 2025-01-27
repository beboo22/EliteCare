using AutoMapper;
using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Core.Mapping;
using EliteCare.Data.Entities;

namespace EliteCare.Api.Mapper
{
    public class AtoMapper : Profile
    {
        public AtoMapper()
        {
            CreateMap<DoctorDtos, Doctor>().ForMember(d => d.Address, s => s.MapFrom(o => o.address));

            CreateMap<AddressDto, Address>();


            CreateMap<Address, AddressReturnDtos>();

            CreateMap<Department, DepartmentReturnDtos>();
            CreateMap<Doctor, TemplateDoctor>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address))
                                               .ForMember(d => d.Department, s => s.MapFrom(o => o.Department))
                                               .ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"));









        }
    }
}
