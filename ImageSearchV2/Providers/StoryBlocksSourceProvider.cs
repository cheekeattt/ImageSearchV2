using AutoMapper;
using ImageSearchV2.Helper;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.ImageSearch.Response;
using ImageSearchV2.Models.StoryBlocks.Request;
using ImageSearchV2.Models.StoryBlocks.Response;
using ImageSearchV2.Models.Unsplash.Request;
using ImageSearchV2.Models.Unsplash.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageSearchV2.Providers
{
    public class StoryBlocksSourceProvider : IStoryBlocksSourceProvider
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _urlPrefix;
        private readonly IMapper _mapper;

        public StoryBlocksSourceProvider(IConfiguration configuration, IMapper mapper)
        {
            _publicKey = configuration["StoryBlocks:PublicKey"];
            _privateKey = configuration["StoryBlocks:PrivateKey"];
            _urlPrefix = configuration["StoryBlocks:UrlPrefix"];
            _mapper = mapper;
        }

        public async Task<List<ImageSearchResponse>> SearchImage(string keyword)
        {
            var expires = StoryblocksHmacHelper.GetExpirationTime();
            var hmac = StoryblocksHmacHelper.GenerateHmac(_privateKey, expires, "/api/v2/images/search");

            var url = BuildUrl(keyword, hmac, expires);

            var storyBlocksResp = await HttpRequestHelper.GetAsync<StoryBlocksResponse>(url);

            if (storyBlocksResp?.Results != null)
            {
                return _mapper.Map<List<ImageSearchResponse>>(storyBlocksResp.Results);
            }
            return new List<ImageSearchResponse>();
        }

        private string BuildUrl(string keyword, string hmac, string expires)
        {
            return $@"{_urlPrefix}?keywords={keyword}&APIKEY={_publicKey}&HMAC={hmac}&EXPIRES={expires}";
        }
    }

}
