using System.Security.Cryptography;
using System.Text;

namespace ImageSearchV2.Helper
{
    public static class StoryblocksHmacHelper
    {
        // Method to generate the expiration time (current Unix timestamp)
        public static string GetExpirationTime()
        {
            return ((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()).ToString();
        }

        // Method to generate the HMAC using the private key, resource, and expiration time
        public static string GenerateHmac(string privateKey, string resource, string expires)
        {
            // Concatenate the private key with the expiration time
            string key = privateKey + expires;

            // Create the HMAC using SHA-256
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                // Compute the hash of the resource (API endpoint)
                byte[] data = Encoding.UTF8.GetBytes(resource);
                byte[] hash = hmac.ComputeHash(data);

                // Return the hash as a hexadecimal string
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
