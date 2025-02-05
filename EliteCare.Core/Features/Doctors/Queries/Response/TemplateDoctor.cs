using EliteCare.Core.Dtos;
using EliteCare.Data.enums;

namespace EliteCare.Core.Features.Doctors.Queries.Response
{
    public class TemplateDoctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public AddressReturnDtos Address { get; set; }
        public string Gender { get; set; }
        public string HireDate { get; set; }
        public string DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentReturnDtos Department { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
