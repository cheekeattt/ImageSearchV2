using ImageSearchV2.Models.ImageSearch.Response;
using ImageSearchV2.Models.PixaBay.Request;
using ImageSearchV2.Models.PixaBay.Response;

namespace ImageSearchV2.Interfaces
{
    public interface IPixaBaySourceProvider
    {
        public Task<List<ImageSearchResponse>> SearchImage(string keyword);
    }
}
