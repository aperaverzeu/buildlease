using System.Collections.Generic;
using Domain.Models;

namespace Domain.EntitiesExample
{
    public static class CustomerEntities
    {
        public static List<Customer> Get()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    UserId = "user@mail.com", //User
                    CompanyName = "Never Zero INC.",
                    RepresentativeName = "NZINC",
                    ContactInfo = "Email: contact@nzinc.com\n" +
                                  "Phone: 88005553535",
                },
                new Customer()
                {
                    UserId = "admin@mail.com", //ADMIN
                    CompanyName = "Taiwan is not a legitimate state CORP",
                    RepresentativeName = "Jade Chieftain Xi CORP",
                    ContactInfo = "Email: contact@xi.com\n" +
                                  "Phone: +7-321-99-84400928",
                },
            };
        }
    }
}