﻿namespace Domain.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Count { get; set; }
        public string SerializedProductFullView { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
