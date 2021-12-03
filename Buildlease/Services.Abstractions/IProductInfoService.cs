using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductInfoService
    {
        ProductInfo GetProductInfo(int productId);
        void SaveProductInfo(ProductInfo info);
        void DeleteProduct(int productId);
    }
}
