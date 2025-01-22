namespace ImageSearchV2.Models.ImageSearch.Request
{
    public class ImageSearchRequest
    {
        public string Keyword { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = 0;
        public int? PerPage { get; set; } = 0;
    }
}
