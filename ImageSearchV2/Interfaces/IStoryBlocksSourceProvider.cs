using ImageSearchV2.Models.StoryBlocks.Request;
using ImageSearchV2.Models.StoryBlocks.Response;

namespace ImageSearchV2.Interfaces
{
    public interface IStoryBlocksSourceProvider
    {
        public Task<StoryBlocksResponse> SearchImage(StoryBlocksRequest request);
    }
}
