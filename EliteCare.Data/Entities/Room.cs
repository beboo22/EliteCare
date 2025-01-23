namespace EliteCare.Data.Entities
{
    public class Room : BaseEntity
    {
        public string Number { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public int DepartmentId { get; set; }
        public int FloorNumber { get; set; }
    }
}