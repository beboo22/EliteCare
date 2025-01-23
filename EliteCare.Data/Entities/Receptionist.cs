using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Entities
{
    public class Receptionist :BaseEntity
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; } 
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }

    }
}
