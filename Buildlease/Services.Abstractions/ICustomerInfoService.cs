using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICustomerInfoService
    {
        CustomerInfo GetCustomerInfo(string userId);
        void SaveCustomerInfo(CustomerInfo info);
    }
}
