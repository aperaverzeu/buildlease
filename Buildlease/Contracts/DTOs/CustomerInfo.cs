using System.Text.Json.Serialization;

namespace Contracts.DTOs
{
    public class CustomerInfo
    {
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string ContactInfo { get; set; }
        public AddressInfo JuridicalAddress { get; set; }
        public AddressInfo[] DeliveryAddresses { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
