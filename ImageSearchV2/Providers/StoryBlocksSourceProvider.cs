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
            // Generate the expiration time and HMAC
            var expires = StoryblocksHmacHelper.GetExpirationTime();
            var hmac = StoryblocksHmacHelper.GenerateHmac(_privateKey, "/api/v2/videos/search", expires);

            // Build the URL with HMAC and expiration time
            var url = BuildUrl(keyword, hmac, expires);

            // Send the request to Storyblocks API and map the response to the desired type
            var storyBlocksResp = await HttpRequestHelper.GetAsync<StoryBlocksResponse>(url);
            if(storyBlocksResp != null)
            {
                return _mapper.Map<List<ImageSearchResponse>>(storyBlocksResp);
            }
            return new List<ImageSearchResponse>();
        }

        private string BuildUrl(string keyword, string hmac, string expires)
        {
            return $@"{_urlPrefix}?keywords={keyword}&APIKEY={_publicKey}&HMAC={hmac}&EXPIRES={expires}";
        }
    }

}
