using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buildlease.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buildlease.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {
        [HttpPost("GetAllCategories")]
        public CaregoryView[] GetAllCategories()
        {
            return new CaregoryView[]
            {
                new()
                {

                },
            };
        }

        [HttpPost("GetCategoryFilters/{categoryId}")]
        public CategoryFilterView[] GetCategoryFilters([FromRoute] int categoryId)
        {
            return new CategoryFilterView[]
            {
                new()
                {

                },
            };
        }

        [HttpPost("GetProducts")]
        public ProductView[] GetProducts()
        {
            return new ProductView[]
            {
                new()
                {

                },
            };
        }

        [HttpPost("GetProduct/{productId}")]
        public ProductFullView GetProduct([FromRoute] int productId)
        {
            return new ProductFullView
            {

            };
        }

        [HttpPost("GetMyOrders")]
        public OrderView[] GetMyOrders()
        {
            return new OrderView[]
            {
                new()
                {

                },
            };
        }

        [HttpPost("GetOrder/{orderId}")]
        public OrderFullView GetOrder([FromRoute] int orderId)
        {
            return new OrderFullView
            {

            };
        }

        [HttpPost("GetMyCart")]
        public CartFullView GetMyCart()
        {
            return new CartFullView()
            {

            };
        }
    }
}
