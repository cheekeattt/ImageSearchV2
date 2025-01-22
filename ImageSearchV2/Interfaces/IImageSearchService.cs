using ImageSearchV2.Models.ImageSearch.Response;

namespace ImageSearchV2.Interfaces
{
    public interface IImageSearchService
    {
        public Task<List<ImageSearchResponse>> Search(string keyword);
    }
}
