using Contracts.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension.Mapping
{
    public static class CustomerMappingExtension
    {
        public static CustomerInfo MapToCustomerInfo(this Customer customer)
        {
            throw new NotImplementedException("You need Include to do this, Master!");
        }

        public static CustomerInfo MapToCustomerInfo(this Customer customer, IEnumerable<Address> addresses)
            => new CustomerInfo()
            {
                UserId = customer.UserId,
                CompanyName = customer.CompanyName,
                ContactInfo = customer.ContactInfo,
                RepresentativeName = customer.RepresentativeName,
                JuridicalAddress = addresses
                    .SingleOrDefault(e => e.Priority == 0)
                    ?.MapToAddressInfo(),
                DeliveryAddresses = addresses
                    .Where(e => e.Priority > 0)
                    .OrderBy(e => e.Priority)
                    .MapToAddressInfo()
                    .ToArray(),
            };

        public static Customer MapToCustomer(this CustomerInfo info)
            => new Customer()
            {
                UserId = info.UserId,
                CompanyName = info.CompanyName,
                ContactInfo = info.ContactInfo,
                RepresentativeName = info.RepresentativeName,
            };
    }
}
