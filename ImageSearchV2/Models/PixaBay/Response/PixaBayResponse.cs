namespace ImageSearchV2.Models.PixaBay.Response
{
    public class PixaBayResponse
    {
        public int Total { get; set; }
        public int TotalHits { get; set; }
        public List<PixabayImage> Hits { get; set; }
    }

    public class PixabayImage
    {
        public int Id { get; set; }
        public string PageURL { get; set; } = null;
        public string Type { get; set; }
        public string Tags { get; set; }
        public string PreviewURL { get; set; }
        public int PreviewWidth { get; set; }
        public int PreviewHeight { get; set; }
        public string WebformatURL { get; set; }
        public int WebformatWidth { get; set; }
        public int WebformatHeight { get; set; }
        public string LargeImageURL { get; set; }
        public string FullHDURL { get; set; }
        public string ImageURL { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int ImageSize { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public string UserImageURL { get; set; }
    }
}
