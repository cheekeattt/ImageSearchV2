using AutoMapper;
using ImageSearchV2.Helper;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.ImageSearch.Response;
using ImageSearchV2.Models.PixaBay.Request;
using ImageSearchV2.Models.PixaBay.Response;
using ImageSearchV2.Models.StoryBlocks.Request;
using ImageSearchV2.Models.StoryBlocks.Response;
using ImageSearchV2.Models.Unsplash.Response;

namespace ImageSearchV2.Providers
{
    public class PixaBaySourceProvider : IPixaBaySourceProvider
    {
        private readonly string _accessKey;
        private readonly string _urlPrefix;

        private readonly IMapper _mapper;

        public PixaBaySourceProvider(IConfiguration configuration, IMapper mapper)
        {
            _accessKey = configuration["PixaBay:AccessKey"];
            _urlPrefix = configuration["PixaBay:UrlPrefix"];
            _mapper = mapper;
        }

        public async Task<List<ImageSearchResponse>> SearchImage(string keyword)
        {
            var url = BuildUrl(keyword);
            var pixaBayResp = await HttpRequestHelper.GetAsync<PixaBayResponse>(url);
            if (pixaBayResp != null) {
                return _mapper.Map<List<ImageSearchResponse>>(pixaBayResp);
            }
            return new List<ImageSearchResponse>();
        }

        private string BuildUrl(string keyword)
        {
            return $@"{_urlPrefix}?q={keyword}&key={_accessKey}";
        }
    }
}
