using EliteCare.Data.Entities;
using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class AddNurseDto
    {
        [MaxLength(100)]
        public string Fname { get; set; }
        [MaxLength(100)]
        public string Sname { get; set; }
        [MaxLength(100)]
        public string Lname { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? RoomID { get; set; }
    }
}
