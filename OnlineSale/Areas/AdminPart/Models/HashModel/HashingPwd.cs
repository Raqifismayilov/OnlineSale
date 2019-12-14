using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.HashModel
{
    public class HashingPwd
    {
        private const int ITERATIONS = 100000;
        private const int SALT_SIZE = 64;
        private const int HASH_SIZE = 64;
        public void SaltAndHashPassword(string password, out byte[] salt, out byte[] hash)
        {
            if (!(string.IsNullOrEmpty(password.Trim())))
            {
                Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(password, SALT_SIZE, ITERATIONS);
                salt = rdb.Salt;
                hash = rdb.GetBytes(HASH_SIZE);
            }
            else
                throw new Exception();
        }
        public bool ValidatePassword(string password, byte[] storedSalt, byte[] storedHash)
        {
            if (!(string.IsNullOrEmpty(password.Trim())))
            {
                Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(password, storedSalt, ITERATIONS);
                byte[] hash = rdb.GetBytes(HASH_SIZE);
                return IsSameByteArrays(storedHash, hash);
            }
            else
                return false;
        }
        private bool IsSameByteArrays(byte[] a, byte[] b)
        {
            if (a.Length != 0 && b.Length != 0)
            {
                if (a.Length != b.Length) return false;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                        return false;
                }
                return true;
            }
            else
                return false;
        }
    }
}