using Contracts.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension.Mapping
{
    public static class AddressMappingExtension
    {
        public static AddressInfo MapToAddressInfo(this Address obj)
            => new()
            {
                Building = obj.Building,
                City = obj.City,
                Office = obj.Office,
                PostalCode = obj.PostalCode,
                Street = obj.Street,
            };

        public static IEnumerable<AddressInfo> MapToAddressInfo(this IEnumerable<Address> objs)
            => objs
                .Select(e => e.MapToAddressInfo());

        public static Address MapToAddress(this AddressInfo obj)
            => new()
            {
                Building = obj.Building,
                City = obj.City,
                Office = obj.Office,
                PostalCode = obj.PostalCode,
                Street = obj.Street,

                CustomerId = null,
                Priority = -1,
            };

        public static IEnumerable<Address> MapToAddress(this IEnumerable<AddressInfo> objs)
            => objs
                .Select(e => e.MapToAddress());
    }
}
