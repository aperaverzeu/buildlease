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
                    UserId = "c65e9a5d-ef9f-450b-b851-f97190da3470", //User
                    CompanyName = "Never Zero INC.",
                    RepresentativeName = "NZINC",
                    ContactInfo = "Email: contact@nzinc.com" +
                                  "Phone: 88005553535",
                    JuridicalAddressId = 4
                },
                new Customer()
                {
                    UserId = "f92039fd-5e51-431e-aefe-4a18e6cc846a", //ADMIN
                    CompanyName = "Taiwan is not a legitimate state CORP",
                    RepresentativeName = "Jade Chieftain Xi CORP",
                    ContactInfo = "Email: contact@xi.com" +
                                  "Phone: +7-321-99-84400928",
                    JuridicalAddressId = null
                },
            };
        }
    }
}