using System;
using System.Security.Cryptography;
using System.Text;

namespace ConfidentialsWebAPI.Helpers
{
    public class EncryptionHelper
    {
        public const string AccessKeyId = "AKIAIOSFODNN7EXAMPLE";
        public const string SecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";

        public static string Encrypt(string data)
        {
            Byte[] secretBytes = UTF8Encoding.UTF8.GetBytes(SecretAccessKey);
            HMACSHA1 hmac = new HMACSHA1(secretBytes);

            Byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(data);
            Byte[] calcHash = hmac.ComputeHash(dataBytes);
            String HashedData = Convert.ToBase64String(calcHash);
            return "AYO" + " " + AccessKeyId + ":" + HashedData;
        }
    }
}
