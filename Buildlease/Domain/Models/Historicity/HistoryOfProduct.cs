using System;

namespace Domain.Models.Historicity
{
    public class HistoryOfProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string SerializedProductFullView { get; set; }
    }
}
