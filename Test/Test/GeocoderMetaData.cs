namespace TestAddressa
{
    public class GeocoderMetaData
    {
        public string precision { get; set; }
        public string text { get; set; }
        public string kind { get; set; }
        public Address Address { get; set; }
        public AddressDetails AddressDetails { get; set; }
    }
}