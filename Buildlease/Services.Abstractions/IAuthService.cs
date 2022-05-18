using Domain.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Services.Abstractions
{
    public interface IAuthService
    {
        void Register(string userId, string password);
        void SendRestoreCode(string userId);
        void ChangePassword(string userId, string restoreCode, string newPassword);

        public static string ComputeHash(string input, string alrogithm = "SHA256")
        {
            using var hasher = HashAlgorithm.Create(alrogithm);
            if (hasher is null) throw new InvalidOperationException("Unknown algorithm");
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = hasher.ComputeHash(inputBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hash;
        }

        public static string ComputeRestoreCode(ApplicationUser user)
            => ComputeHash(user.Id + user.PasswordHash, "MD5")[..6];
    }
}
