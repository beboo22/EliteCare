using EliteCare.Core.Dtos;
using EliteCare.Data.Entities;
using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Nurse.Queries.Response
{
    public class TemplateNurse
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? RoomID { get; set; }
        public RoomToReturnDtos GovernRoom { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
