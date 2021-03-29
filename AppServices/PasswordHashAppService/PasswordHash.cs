using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRService.AppServices.PasswordHashAppService
{
    public class PasswordHash : IPasswordHash
    {
        public string GetHashedPassword(string password)
        {
            var hashedPassword = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));
            for (int i = 0; i < bytes.Length; i++)
            {
                hashedPassword.Append(bytes[i].ToString("X2"));
            }
            return hashedPassword.ToString();
        }
    }
}
