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
                    IsAdmin = false,
                    Id = "c65e9a5d-ef9f-450b-b851-f97190da3470",
                    UserName = "user@mail.com",
                    NormalizedUserName = "USER@MAIL.COM",
                    Email = "user@mail.com",
                    NormalizedEmail = "USER@MAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEPYwBPYBYGyhKgban6l394/T53IiRO4uG8EXgKWORDZJKyVql2WiJk0EMfX9dtB3eg==",
                    SecurityStamp = "RFSI4ALMU5DOAJXUUNQ6KQRNKUBZ3QHC",
                    ConcurrencyStamp = "543bf42f-9ba3-4852-b17b-a515cdadf191",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser()
                {
                    IsAdmin = true,
                    Id = "f92039fd-5e51-431e-aefe-4a18e6cc846a",
                    UserName = "admin@mail.com",
                    NormalizedUserName = "ADMIN@MAIL.COM",
                    Email = "admin@mail.com",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEKuydO2bZTazovWisCQ+53sobjE+vJMoGb1xqZZUTCu9U5CJdpzgA6NjKYWTG+c9JQ==",
                    SecurityStamp = "VYAZGS6FTEV56IIADFHZDP57E4RL7AWP",
                    ConcurrencyStamp = "fb09b08c-8af3-455e-8b41-cd875727ca6a",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            };
        }
    }
}