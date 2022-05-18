using System.Collections.Generic;
using Domain.Models;

namespace Domain.EntitiesExample
{
    public static class UserEntities
    {
        public static List<ApplicationUser> Get()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "user@mail.com",
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                    IsAdmin = false,
                },
                new ApplicationUser()
                {
                    Id = "admin@mail.com",
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                    IsAdmin = true,
                }
            };
        }
    }
}