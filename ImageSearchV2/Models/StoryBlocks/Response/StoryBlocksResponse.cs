namespace ImageSearchV2.Models.StoryBlocks.Response
{
    public class StoryBlocksResponse
    {
        public int TotalResults { get; set; }
        public List<StoryblocksResult> Results { get; set; }
    }

    public class StoryblocksResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ThumbnailUrl { get; set; }
        public string PreviewUrl { get; set; }
        public bool IsNew { get; set; }
    }
}
