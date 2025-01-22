using ImageSearchV2.Interfaces;
using ImageSearchV2.Query;
using ImageSearchV2.Providers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ImageSearchV2.Services;
using ImageSearchV2;
using ImageSearch.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnsplashSourceProvider, UnsplashSourceProvider>();
builder.Services.AddScoped<IStoryBlocksSourceProvider, StoryBlocksSourceProvider>();
builder.Services.AddScoped<IPixaBaySourceProvider, PixaBaySourceProvider>();
builder.Services.AddScoped<IImageSearchService, ImageSearchService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .AddQueryType<ImageSearchQuery>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddAutoMapper(typeof(ImageSearchMapper));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;        
    });    
}
app.MapGraphQL("/graphql");
app.MapControllers();
app.Run();
