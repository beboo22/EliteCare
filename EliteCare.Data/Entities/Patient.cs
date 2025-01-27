using EliteCare.Data.enums;

namespace EliteCare.Data.Entities
{
    public class Patient : BaseEntity
    {
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Lname { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public Gender Gender { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public int AddressId { get; set; } 
        public Address Address { get; set; } 
        public BloodType BloodType { get; set; } 
        public string EmergencyContact { get; set; } 
        public string MedicalHistory { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}