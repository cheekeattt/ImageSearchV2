using ImageSearchV2.Models.ImageSearch.Response;
using ImageSearchV2.Models.StoryBlocks.Request;
using ImageSearchV2.Models.StoryBlocks.Response;

namespace ImageSearchV2.Interfaces
{
    public interface IStoryBlocksSourceProvider
    {
        public Task<List<ImageSearchResponse>> SearchImage(string keyword);
    }
}
