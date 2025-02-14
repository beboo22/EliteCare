using AutoMapper;
using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Authorizations.Queries.Response;
using EliteCare.Core.Features.Departments.Queries.Response;
using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Core.Features.patients.Queries.Response;
using EliteCare.Core.Features.Receptionists.Queries.Response;
using EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Validations;
using EliteCare.Core.Mapping;
using EliteCare.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace EliteCare.Api.Mapper
{
    public class AtoMapper : Profile
    {
        public AtoMapper()
        {
            CreateMap<AddDoctorDtos, Doctor>().ForMember(d => d.Address, s => s.MapFrom(o => o.address));
            CreateMap<UpdateDoctorDtos, Doctor>().ForMember(d => d.Address, s => s.MapFrom(o => o.address));





            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressReturnDtos>();
            CreateMap<UpdateAddressDto, Address>();

            CreateMap<Department, DepartmentReturnDtos>();
            CreateMap<Doctor, TemplateDoctor>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address))
                                               .ForMember(d => d.Department, s => s.MapFrom(o => o.Department))
                                               .ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"));




            CreateMap<Nurse, TemplateNurse>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address))
                                          .ForMember(d => d.GovernRoom, s => s.MapFrom(s => s.GovernRoom))
                                          .ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"));

            CreateMap<Room, RoomToReturnDtos>();

            CreateMap<AddNurseDto, Nurse>();
            CreateMap<SpecialistDoctorInDepartment, TemplateSpecialist>().ForMember(d => d.DepartmentName, s => s.MapFrom(o => o.Department.Name))
                                                                         .ForMember(d => d.DoctorName, s => s.MapFrom(o => $"{o.Doctor.Fname} {o.Doctor.Sname} {o.Doctor.Lname}"));


            CreateMap<Department, AddDepartmentDto>();
            CreateMap<Department, UpdateDepartmentDto>();

            CreateMap<Department, TemplateDepartment>();

            CreateMap<UpdateReceptionistDto, Receptionist>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address));
            CreateMap<AddReceptionistDto, Receptionist>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address));

            CreateMap<Receptionist, TemplateReceptionist>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address))
                                                           .ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"));
            
            
            CreateMap<Patient, TemplatePatient>().ForMember(d => d.Address, s => s.MapFrom(o => o.Address))
                                                           .ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"));


            CreateMap<Appointment, AppointmentReturnDto>();

            CreateMap<AddAppointmentDtos, Appointment>();
            CreateMap<UpdateAppointmentDtos, Appointment>();

            CreateMap<Prescription, PrescriptionReturnToAppointmentDto>();
            CreateMap<Receptionist, ReceptionistReturnToAppointmentDtos>();                                                                         
            CreateMap<Patient, PatientReturnToAppointmentDtos>().ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"));
            CreateMap<Doctor, DoctorReturnToAppointmentDtos>().ForMember(d => d.Name, s => s.MapFrom(o => $"{o.Fname} {o.Sname} {o.Lname}"))
                                                               .ForMember(d => d.DepartmentName, S => S.MapFrom(o => o.Department != null ? o.Department.Name : ""));
            CreateMap<Bill,BillReturnDto>();
            CreateMap<AddBillDto,Bill>();


            CreateMap<IdentityRole<int>, TemplateRole>();

        }
    }
}
