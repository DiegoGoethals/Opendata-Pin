namespace Pin.OpenData.Blazor.Models
{
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public GeoPoint2D GeoPoint2D { get; set; }
        public Geometry Geometry { get; set; }
        public string ImageLink { get; set; }
    }
}
