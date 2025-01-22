using ImageSearchV2.Constants;

namespace ImageSearchV2.Models.ImageSearch.Response
{
    public class ImageSearchResponse
    {
        public string ImageID { get; set; } // The ID of the image
        public string Thumbnails { get; set; } // Thumbnails URL of the image
        public string Preview { get; set; } // Preview URL of the image
        public string Title { get; set; } // Title of the image
        public ImageSource Source { get; set; } // Image library source (Unsplash, Storyblocks, Pixabay)
        public List<string> Tags { get; set; } // Tags/keywords associated with the image

        public ImageSearchResponse()
        {
            Tags = new List<string>();
        }
    }
}
