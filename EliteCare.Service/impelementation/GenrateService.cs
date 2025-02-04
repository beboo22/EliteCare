using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Infrastructure;
using EliteCare.Service.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteCare.Service.specificationCriteria;
using EliteCare.Data.Specification;

namespace EliteCare.Service.impelementation
{
    public class GenrateService : IGenrateService
    {
        private Hashtable hashtable;
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
            //else if(typeof(T) == typeof(Appointment))
            //{
            //    return new AppointmentService(DoctorRepo, _unitOfWork, _context);
            //}
            else if (typeof(T) == typeof(Nurse))
            {
                return (ISpecification<T>)new NurseSpecification(null, id);
            }
            else
            {
                return null;
            }
        }
    }
}
