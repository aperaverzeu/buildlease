﻿namespace Contracts.DTOs
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public ProductAttributeInfo[] Attributes { get; set; }
    }
}
