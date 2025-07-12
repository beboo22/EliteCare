using EliteCare.Data.Entities;

namespace EliteCare.Data.Abstract
{
    public interface IDoctorRepo : IGenericRepository<Doctor>
    {
        Task<Doctor> GetDoctorByEmail(string email);
        Task<IEnumerable<Doctor>> GetDoctorForDept(int departmentId);
        Task<IEnumerable<Doctor>> SpecialistDoctorInDepartment(int departmentId);
        Task<IEnumerable<Appointment>> GetAppointments(int DoctorId);
    }
}
