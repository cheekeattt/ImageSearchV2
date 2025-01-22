using ImageSearchV2.Helper;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.StoryBlocks.Request;
using ImageSearchV2.Models.StoryBlocks.Response;
using ImageSearchV2.Models.Unsplash.Request;
using ImageSearchV2.Models.Unsplash.Response;

namespace ImageSearchV2.Services
{
    public class StoryBlocksSourceProvider : IStoryBlocksSourceProvider
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _urlPrefix;

        private static string _url = string.Empty;

        public StoryBlocksSourceProvider(IConfiguration configuration)
        {
            _accessKey = configuration["UnsplashSettings:AccessKey"];
            _secretKey = configuration["UnsplashSettings:SecretKey"];
            _urlPrefix = configuration["UnsplashSettings:UrlPrefix"];
        }

        public async Task<StoryBlocksResponse> SearchImage(StoryBlocksRequest request)
        {
            return await HttpRequestHelper.GetAsync<StoryBlocksResponse>(_url);
        }
    }
}
