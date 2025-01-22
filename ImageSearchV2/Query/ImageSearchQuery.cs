using GraphQL.Types;
using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.ImageSearch.Response;

namespace ImageSearchV2.Query
{
    public class ImageSearchQuery
    {
        private readonly IImageSearchService _imageSearchService;

        public ImageSearchQuery(IImageSearchService imageSearchService)
        {
            _imageSearchService = imageSearchService;
        }

        public async Task<List<ImageSearchResponse>> SearchImages(string keyword)
        {
            return await _imageSearchService.Search(keyword);
        }
    }
}
