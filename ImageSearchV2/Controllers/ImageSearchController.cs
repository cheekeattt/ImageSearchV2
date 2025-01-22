using ImageSearchV2.Interfaces;
using ImageSearchV2.Models.ImageSearch.Request;
using ImageSearchV2.Models.ImageSearch.Response;
using Microsoft.AspNetCore.Mvc;

namespace ImageSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageSearchController : ControllerBase
    {

        private readonly IImageSearchService _imageSearchService;
        
        public ImageSearchController(IImageSearchService imageSearchService)
        {
            _imageSearchService = imageSearchService;
        }

        [HttpGet]
        [Route("/search-image")]
        public async Task<List<ImageSearchResponse>> SearchImage(string keyWord)
        {
            return await _imageSearchService.Search(keyWord);
        }
    }
}
