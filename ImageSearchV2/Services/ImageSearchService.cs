using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.ImageSearch.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageSearchV2.Services
{
    public class ImageSearchService : IImageSearchService
    {
        private readonly IPixaBaySourceProvider _pixaBaySourceProvider;
        private readonly IStoryBlocksSourceProvider _storyBlocksSourceProvider;
        private readonly IUnsplashSourceProvider _unsplashSourceProvider;

        private readonly List<ImageSearchResponse> result = new List<ImageSearchResponse>();

        public ImageSearchService(
            IUnsplashSourceProvider unsplashSourceProvider,
            IStoryBlocksSourceProvider storyBlocksSourceProvider,
            IPixaBaySourceProvider pixaBaySourceProvider
        )
        {
            _unsplashSourceProvider = unsplashSourceProvider;
            _storyBlocksSourceProvider = storyBlocksSourceProvider;
            _pixaBaySourceProvider = pixaBaySourceProvider;
        }

        public async Task<List<ImageSearchResponse>> Search(string keyword)
        {
            var unsplashTask = _unsplashSourceProvider.SearchImage(keyword);
            var pixaBayTask = _pixaBaySourceProvider.SearchImage(keyword);
            var storyBlocksTask = _storyBlocksSourceProvider.SearchImage(keyword);

            await Task.WhenAll(unsplashTask, pixaBayTask, storyBlocksTask);

            result.AddRange(unsplashTask.Result);
            result.AddRange(pixaBayTask.Result);
            result.AddRange(storyBlocksTask.Result);

            return result;
        }
    }
}
