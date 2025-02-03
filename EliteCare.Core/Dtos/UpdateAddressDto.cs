namespace EliteCare.Core.Dtos
{
    public class UpdateAddressDto
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string country { get; set; } = null!;
        public string Zip { get; set; } = null!;
    }
}