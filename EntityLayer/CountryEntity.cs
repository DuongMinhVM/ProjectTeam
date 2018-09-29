namespace EntityLayer
{
    public class CountryEntity : BaseEntity
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string CityPrefix { get; set; }
        public string CitySuffix { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }

        public string StreetSuffix { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Direction { get; set; }
        public string CardinalDirection { get; set; }
        public string OrdinalDirection { get; set; }
    }
}