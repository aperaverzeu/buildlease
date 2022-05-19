using System.Collections.Generic;
using Domain.Models;

namespace Domain.EntitiesExample
{
    public static class AddressEntities
    {
        public static List<Address> Get()
        {
            return new List<Address>()
            {
                new Address()
                {
                    Id = -5,
                    CustomerId = "admin@mail.com", 
                    Priority = 1,
                    PostalCode = "602-8570",
                    City = "Kyoto",
                    Street = "Ahimabary st.",
                    Building = "Skyscraper",
                    Office = "Tepee on the fifth floor near the toilet"
                },
                new Address()
                {
                    Id = -1,
                    CustomerId = "user@mail.com", 
                    Priority = 3,
                    PostalCode = "301-3322",
                    City = "Dortmund",
                    Street = "Karl strasse st",
                    Building = "Loft",
                    Office = "Single room apartment",
                },
                new Address()
                {
                    Id = -2,
                    CustomerId = "user@mail.com", 
                    Priority = 1,
                    PostalCode = "111-6666",
                    City = "Reykjavik",
                    Street = "Monderlstotrm underlstom St",
                    Building = "House",
                    Office = "Room overlooking the geyser",
                },
                new Address()
                {
                    Id = -3,
                    CustomerId = "user@mail.com", 
                    Priority = 2,
                    PostalCode = "4455-112",
                    City = "Lisbon",
                    Street = "Pedro Gonsales st",
                    Building = "Great house",
                    Office = "Near ocean",
                },
                new Address()
                {
                    Id = -4,
                    CustomerId = "user@mail.com", 
                    Priority = 0,
                    PostalCode = "69-420",
                    City = "New-York",
                    Street = "Central park st",
                    Building = "Skyscraper",
                    Office = "Overlooking central park",
                }
            };
        }
    }
}