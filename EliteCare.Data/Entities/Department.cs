namespace EliteCare.Data.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } 
        public string Code { get; set; } 
        public string Description { get; set; }
        public int FloorNumber { get; set; } 
        public string PhoneNumber { get; set; }

    }
}