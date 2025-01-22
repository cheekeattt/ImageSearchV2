using AutoMapper;
using ImageSearchV2.Helper;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.ImageSearch.Response;
using ImageSearchV2.Models.Unsplash.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageSearchV2.Providers
{
    public class UnsplashSourceProvider : IUnsplashSourceProvider
    {
        private readonly string _accessKey;
        private readonly string _urlPrefix;
        private readonly IMapper _mapper;

        public UnsplashSourceProvider(IConfiguration configuration, IMapper mapper)
        {
            _accessKey = configuration["UnsplashSettings:AccessKey"];
            _urlPrefix = configuration["UnsplashSettings:UrlPrefix"];
            _mapper = mapper;
        }

        public async Task<List<ImageSearchResponse>> SearchImage(string keyword)
        {
            var url = BuildUrl(keyword);
            var unsplashResp = await HttpRequestHelper.GetAsync<UnsplashResponse>(url);
            if (unsplashResp != null) {
                return _mapper.Map<List<ImageSearchResponse>>(unsplashResp);
            }
            return new List<ImageSearchResponse>();
        }

        private string BuildUrl(string keyword)
        {
            return $@"{_urlPrefix}?query={keyword}&client_id={_accessKey}";
        }
    }
}
