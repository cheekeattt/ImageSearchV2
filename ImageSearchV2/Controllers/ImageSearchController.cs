using ImageSearchV2.Models.ImageSearch.Request;
using Microsoft.AspNetCore.Mvc;

namespace ImageSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageSearchController : ControllerBase
    {        
        [HttpGet]
        public bool Get(ImageSearchRequest request)
        {
            return true;
        }
    }
}
