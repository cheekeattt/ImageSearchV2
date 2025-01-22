using AutoMapper;
using ImageSearchV2.Constants;
using ImageSearchV2.Models.ImageSearch.Response;
using ImageSearchV2.Models.PixaBay.Response;
using ImageSearchV2.Models.Unsplash.Response;

namespace ImageSearchV2
{
    public class ImageSearchMapper : Profile
    {
        public ImageSearchMapper()
        {
            // Mapping for UnsplashResponse to List<ImageSearchResponse>
            CreateMap<UnsplashResponse, List<ImageSearchResponse>>()
                .ConvertUsing(src => src.Results.Select(photo => new ImageSearchResponse
                {
                    ImageID = photo.Id,
                    Title = photo.Description ?? "Untitled",
                    Thumbnails = photo.Urls.Raw,
                    Preview = photo.Urls.Full,
                    Source = nameof(ImageSource.Unsplash),
                    Tags = new List<string>()
                }).ToList());

            // Mapping for PixabayImage to ImageSearchResponse
            CreateMap<PixabayImage, ImageSearchResponse>()
                .ForMember(dest => dest.ImageID, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Thumbnails, opt => opt.MapFrom(src => src.PreviewURL))
                .ForMember(dest => dest.Preview, opt => opt.MapFrom(src => src.WebformatURL))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => (string?)null))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom<CustomTagsResolver>())
                .ForMember(dest => dest.Source, opt => opt.MapFrom(_ => nameof(ImageSource.Pixabay)));

            // Mapping for PixabayResponse to List<ImageSearchResponse>
            CreateMap<PixaBayResponse, List<ImageSearchResponse>>()
                .ConvertUsing((src, _, context) =>
                    src.Hits.Select(hit => context.Mapper.Map<ImageSearchResponse>(hit)).ToList());
        }
    }

    public class CustomTagsResolver : IValueResolver<PixabayImage, ImageSearchResponse, List<string>>
    {
        public List<string> Resolve(PixabayImage source, ImageSearchResponse destination, List<string> destMember, ResolutionContext context)
        {
            return source.Tags!.Split(',').ToList() ?? new List<string>();
        }
    }
}
