using System;

namespace Domain.Models.Historicity
{
    public class HistoryOfCustomer
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string SerializedCustomerInfo { get; set; }
    }
}
