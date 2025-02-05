using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.specificationCriteria
{
    public class NurseSpecification : Specification<Nurse>
    {
        public NurseSpecification(string? Email, int? id, int? RoomId)
                                    : base(n => (string.IsNullOrEmpty(Email) || n.Email.ToLower() == Email.ToLower())
                                               && (!id.HasValue || n.ID == id)
                                                && (!RoomId.HasValue || n.RoomID == RoomId))
        {
            AddInclude(n => n.Address);
            AddInclude(n => n.GovernRoom);
        }
    }
}
