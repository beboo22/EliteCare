using EliteCare.Data.Entities;
using EliteCare.Service.specificationCriteria;
using EliteCare.Data.Specification;
using EliteCare.Data.ServiceAbstract;

namespace EliteCare.Service.impelementation
{
    public class GenrateService : IGenrateService
    {
        public async Task<ISpecification<T>> GenerateService<T>(int id) where T : BaseEntity, new()
        {

            if (typeof(T) == typeof(Doctor))
            {
                return (ISpecification<T>)new DoctorSpecification(null, id, null);
            }
            else if (typeof(T) == typeof(Patient))
            {
                return (ISpecification<T>)new PatientSpecification(null, id);
            }
            else if (typeof(T) == typeof(Nurse))
            {
                return (ISpecification<T>)new NurseSpecification(null, id,null);
            }
            else
            {
                return null;
            }
        }
    }
}
