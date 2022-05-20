using Persistence;
using Services.Abstractions;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Services
{
    internal sealed class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;

        public AuthService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        public void Register(string userId, string password)
        {
            if (_db.Users.Any(u => u.Id == userId))
                throw new InvalidOperationException("User with such login already exists");

            _db.Users.Add(new()
            {
                Id = userId,
                PasswordHash = IAuthService.ComputeHash(password),
                IsAdmin = false,
            });

            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            when (
                ex.InnerException is Microsoft.Data.SqlClient.SqlException inner &&
                inner.Procedure == "UserEmailValidation")
            {
                throw new InvalidOperationException("Email is not valid");
            }
        }

        public void Login(string userId, string password)
        {
            if (_db.Users.All(u => u.Id != userId))
                throw new InvalidOperationException("There is no user with such login");

            var user = _db.Users.Single(u => u.Id == userId);

            if (user.PasswordHash != IAuthService.ComputeHash(password))
                throw new InvalidOperationException("Wrong password");
        }

        public void SendRestoreCode(string userId)
        {
            if (_db.Users.All(u => u.Id != userId))
                throw new InvalidOperationException("There is no user with such login");

            var user = _db.Users.Single(u => u.Id == userId);

            var restoreCode = IAuthService.ComputeRestoreCode(user);

            var smtpClient = new SmtpClient("mail.rigorich.monster", 587)
            {
                Credentials = new NetworkCredential("buildlease@rigorich.monster", "password"),
            };

            smtpClient.Send("buildlease@rigorich.monster", userId, "Buildlease: Password restoring", $"Your restore code is {restoreCode}");
        }

        public void ChangePassword(string userId, string restoreCode, string newPassword)
        {
            if (_db.Users.All(u => u.Id != userId))
                throw new InvalidOperationException("There is no user with such login");

            var user = _db.Users.Single(u => u.Id == userId);

            if (restoreCode != IAuthService.ComputeRestoreCode(user))
                throw new InvalidOperationException("Wrong restore code");

            user.PasswordHash = IAuthService.ComputeHash(newPassword);

            _db.SaveChanges();
        }
    }
}
