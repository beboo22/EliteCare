using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Entities
{
    public class Receptionist :BaseEntity
    {
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; } 
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Appointment> Appointments { get; set; }


    }
}
