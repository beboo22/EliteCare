using EliteCare.Data.Entities;
using EliteCare.Data.Specification;

namespace EliteCare.Service.specificationCriteria
{
    internal class PatientSpecification : Specification<Patient>
    {
        public PatientSpecification(string? Email, int? patientId)
            : base(
                  d => (string.IsNullOrEmpty(Email) || d.Email.ToLower() == Email.ToLower())
                  && (!patientId.HasValue || d.ID == patientId.Value))
        {
            AddInclude(p => p.Address);
            AddInclude(p => p.Appointments);
        }
    }
}
