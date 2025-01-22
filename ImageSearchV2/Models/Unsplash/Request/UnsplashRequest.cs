namespace ImageSearchV2.Models.Unsplash.Request
{
    public class UnsplashRequest
    {
        public string Query { get; set; } = string.Empty;
        public int Page { get; set; } = 0;
        public int PerPage { get; set; } = 0;
    }
}
