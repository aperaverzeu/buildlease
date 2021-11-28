using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer
    {
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string ContactInfo { get; set; }
        public int? JuridicalAddressId { get; set; }

        //public IEnumerable<Order> Orders { get; set; }
    }
}
