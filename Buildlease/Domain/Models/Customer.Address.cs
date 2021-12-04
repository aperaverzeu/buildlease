namespace Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int Priority { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Office { get; set; }

        public Customer Customer { get; set; }
    }
}
