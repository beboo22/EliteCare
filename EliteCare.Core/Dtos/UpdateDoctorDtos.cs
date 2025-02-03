using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class UpdateDoctorDtos
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Fname { get; set; } = null!;

        [MaxLength(100)]
        public string Lname { get; set; } = null!;

        [MaxLength(100)]
        public string Sname { get; set; } = null!;

        [MaxLength(11)]
        public string PhoneNumber { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public int Gender { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public UpdateAddressDto address { get; set; }
    }
}
