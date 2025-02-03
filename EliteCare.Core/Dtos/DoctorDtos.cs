using EliteCare.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace EliteCare.Core.Mapping
{
    public class AddDoctorDtos
    {
        [MaxLength(100)]
        public string Fname { get; set; }
        [MaxLength(100)]
        public string Lname { get; set; }
        [MaxLength(100)]
        public string Sname { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }

        public AddressDto address { get; set; }


    }
}
