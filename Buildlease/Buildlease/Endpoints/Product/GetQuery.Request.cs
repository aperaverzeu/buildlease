using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Buildlease.Data;
using Buildlease.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buildlease.Endpoints.Product
{
    public class GetQueryRequest
    {
        public int CategoryId { get; set; }
        public AttributeFilter[] Filters { get; set; }
        public SortRule OrderByRule { get; set; }
        public int SkipCount { get; set; }
        public int TakeCount { get; set; }
    }
}
