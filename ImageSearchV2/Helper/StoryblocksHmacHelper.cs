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
        public static string GenerateHmac(string privateKey, string expires, string resource)
        {
            // Combine the private key and expires timestamp
            var key = Encoding.UTF8.GetBytes(privateKey + expires);

            // Convert the resource to a byte array
            var resourceBytes = Encoding.UTF8.GetBytes(resource);

            // Create the HMAC-SHA256 hash
            using (var hmac = new HMACSHA256(key))
            {
                var hashBytes = hmac.ComputeHash(resourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
