using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImageSearchV2.Helper
{
    public static class HttpRequestHelper
    {
        private static readonly HttpClient _client = new HttpClient();

        // Set a reasonable timeout for the HttpClient
        static HttpRequestHelper()
        {
            _client.Timeout = TimeSpan.FromSeconds(30);  // You can adjust the timeout duration based on your needs
        }

        // GET request with enhanced error handling
        public static async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    // Log error or handle accordingly
                    Console.Error.WriteLine($"GET request failed. Status Code: {response.StatusCode}, URL: {url}");
                    return default; // Return default (null) in case of non-200 status code
                }
            }
            catch (TaskCanceledException)
            {
                // Handle timeout
                Console.Error.WriteLine($"Request timed out. URL: {url}");
                return default; // Return null on timeout
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.Error.WriteLine($"Error during GET request. URL: {url}, Exception: {ex.Message}");
                return default; // Return null on other errors
            }
        }

        // POST request with enhanced error handling
        public static async Task<T> PostAsync<T>(string url, object data)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    // Log error or handle accordingly
                    Console.Error.WriteLine($"POST request failed. Status Code: {response.StatusCode}, URL: {url}");
                    return default; // Return default (null) in case of non-200 status code
                }
            }
            catch (TaskCanceledException)
            {
                // Handle timeout
                Console.Error.WriteLine($"Request timed out. URL: {url}");
                return default; // Return null on timeout
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.Error.WriteLine($"Error during POST request. URL: {url}, Exception: {ex.Message}");
                return default; // Return null on other errors
            }
        }

        // PUT request with enhanced error handling
        public static async Task<T> PutAsync<T>(string url, object data)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(url, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    // Log error or handle accordingly
                    Console.Error.WriteLine($"PUT request failed. Status Code: {response.StatusCode}, URL: {url}");
                    return default; // Return default (null) in case of non-200 status code
                }
            }
            catch (TaskCanceledException)
            {
                // Handle timeout
                Console.Error.WriteLine($"Request timed out. URL: {url}");
                return default; // Return null on timeout
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.Error.WriteLine($"Error during PUT request. URL: {url}, Exception: {ex.Message}");
                return default; // Return null on other errors
            }
        }

        // DELETE request with enhanced error handling
        public static async Task<bool> DeleteAsync(string url)
        {
            try
            {
                var response = await _client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Log error or handle accordingly
                    Console.Error.WriteLine($"DELETE request failed. Status Code: {response.StatusCode}, URL: {url}");
                    return false;
                }
            }
            catch (TaskCanceledException)
            {
                // Handle timeout
                Console.Error.WriteLine($"Request timed out. URL: {url}");
                return false; // Return false on timeout
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.Error.WriteLine($"Error during DELETE request. URL: {url}, Exception: {ex.Message}");
                return false; // Return false on other errors
            }
        }
    }
}
