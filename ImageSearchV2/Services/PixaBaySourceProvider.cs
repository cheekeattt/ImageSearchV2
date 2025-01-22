using ImageSearchV2.Helper;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.PixaBay.Request;
using ImageSearchV2.Models.PixaBay.Response;
using ImageSearchV2.Models.StoryBlocks.Request;
using ImageSearchV2.Models.StoryBlocks.Response;

namespace ImageSearchV2.Services
{
    public class PixaBaySourceProvider : IPixaBaySourceProvider
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _urlPrefix;

        private static string _url = string.Empty;

        public PixaBaySourceProvider(IConfiguration configuration)
        {
            _accessKey = configuration["UnsplashSettings:AccessKey"];
            _secretKey = configuration["UnsplashSettings:SecretKey"];
            _urlPrefix = configuration["UnsplashSettings:UrlPrefix"];
        }

        public async Task<PixaBayResponse> SearchImage(PixaBayRequest request)
        {
            return await HttpRequestHelper.GetAsync<PixaBayResponse>(_url);
        }
    }
}
