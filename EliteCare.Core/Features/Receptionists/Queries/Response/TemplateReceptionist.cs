using EliteCare.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Queries.Response
{
    public class TemplateReceptionist
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; } = true;
      
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public AddressReturnDtos Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
    }
}
