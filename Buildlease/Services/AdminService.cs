using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using Services.Extension;
using System;
using System.Linq;

namespace Services
{
    internal sealed class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _db;

        public AdminService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        public bool IsUserAdmin(string userId)
            =>
            _db.Users
            .SingleOrDefault(e => e.Id == userId)
            ?.IsAdmin
            ?? false;

        public void EnsureUserIsAdmin(string userId)
        {
            if (!IsUserAdmin(userId))
                throw new UnauthorizedAccessException("User is not admin");
        }

    }
}
