using EliteCare.Core.Dtos;
using EliteCare.Data.Entities;
using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Queries.Response
{
    public class TemplatePatient
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public AddressReturnDtos Address { get; set; }
        public string BloodType { get; set; }
        public string EmergencyContact { get; set; }
        public string MedicalHistory { get; set; }
    }
}
