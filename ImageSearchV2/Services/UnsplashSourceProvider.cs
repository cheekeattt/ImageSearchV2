using ImageSearchV2.Helper;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.Unsplash.Request;
using ImageSearchV2.Models.Unsplash.Response;

namespace ImageSearchV2.Services
{
    public class UnsplashSourceProvider : IUnsplashSourceProvider
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _urlPrefix;
        
        private static string _url = string.Empty;

        public UnsplashSourceProvider(IConfiguration configuration)
        {            
            _accessKey = configuration["UnsplashSettings:AccessKey"];
            _secretKey = configuration["UnsplashSettings:SecretKey"];
            _urlPrefix = configuration["UnsplashSettings:UrlPrefix"];
        }

        public async Task<UnsplashResponse> SearchImage(UnsplashRequest request)
        {
            return await HttpRequestHelper.GetAsync<UnsplashResponse>(_url);
        }
    }
}
