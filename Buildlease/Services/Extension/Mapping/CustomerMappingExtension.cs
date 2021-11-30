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
            => new()
            {
                UserId = customer.UserId,
                CompanyName = customer.CompanyName,
                ContactInfo = customer.ContactInfo,
                RepresentativeName = customer.RepresentativeName,
                JuridicalAddress = customer.Addresses
                        .SingleOrDefault(e => e.Priority == 0)
                        ?.MapToAddressInfo(),
                DeliveryAddresses = customer.Addresses
                        .Where(e => e.Priority > 0)
                        .OrderBy(e => e.Priority)
                        .MapToAddressInfo()
                        .ToArray(),
            };

        public static CustomerInfo MapToCustomerInfo(this Customer customer, IEnumerable<Address> addresses)
            => new()
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
            => new()
            {
                UserId = info.UserId,
                CompanyName = info.CompanyName,
                ContactInfo = info.ContactInfo,
                RepresentativeName = info.RepresentativeName,
            };
    }
}
