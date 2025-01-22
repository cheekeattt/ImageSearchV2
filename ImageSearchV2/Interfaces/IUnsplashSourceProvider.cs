using ImageSearchV2.Models.Unsplash.Request;
using ImageSearchV2.Models.Unsplash.Response;

namespace ImageSearchV2.Interfaces
{
    public interface IUnsplashSourceProvider
    {
        public Task<UnsplashResponse> SearchImage(UnsplashRequest request);
    }
}
