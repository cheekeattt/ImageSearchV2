namespace ImageSearchV2.Models.Unsplash.Response
{
    public class UnsplashResponse
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<Photo> Results { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InstagramUsername { get; set; }
        public string TwitterUsername { get; set; }
        public string PortfolioUrl { get; set; }
        public ProfileImage ProfileImage { get; set; }
        public Links Links { get; set; }
    }

    public class ProfileImage
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }

    public class Links
    {
        public string Self { get; set; }
        public string Html { get; set; }
        public string Photos { get; set; }
        public string Likes { get; set; }
    }

    public class Photo
    {
        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public string BlurHash { get; set; }
        public int Likes { get; set; }
        public bool LikedByUser { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public List<object> CurrentUserCollections { get; set; }
        public Urls Urls { get; set; }
    }

    public class Urls
    {
        public string Raw { get; set; }
        public string Full { get; set; }
    }
}
