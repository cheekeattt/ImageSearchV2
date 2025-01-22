using System.Text;
using Newtonsoft.Json;

namespace ImageSearchV2.Helper
{
    public static class HttpRequestHelper
    {
        private static readonly HttpClient _client = new HttpClient();

        // GET request
        public static async Task<T> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        // POST request
        public static async Task<T> PostAsync<T>(string url, object data)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, jsonContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        // PUT request
        public static async Task<T> PutAsync<T>(string url, object data)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(url, jsonContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        // DELETE request
        public static async Task<bool> DeleteAsync(string url)
        {
            var response = await _client.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
