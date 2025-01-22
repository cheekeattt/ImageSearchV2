using ImageSearchV2.Constants;

namespace ImageSearchV2.Models.ImageSearch.Response
{
    public class ImageSearchResponse
    {
        public string? ImageID { get; set; } = string.Empty;
        public string? Thumbnails { get; set; } = string.Empty;
        public string? Preview { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string? Source { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
